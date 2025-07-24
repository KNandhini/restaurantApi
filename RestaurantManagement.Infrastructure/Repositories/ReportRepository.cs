using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Constants;
using RestaurantManagement.Infrastructure.DatabaseConnection;
using RestaurantManagement.Infrastructure.Interfaces;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ClosedXML.Excel;
namespace RestaurantManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on bill.
    /// </summary>
    public class ReportRepository : IReportRepository
    {
        private readonly IDataBaseConnection _db;
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public ReportRepository(IDataBaseConnection db, IConfiguration configuration)
        {
            this._db = db;
            _connectionString = configuration.GetConnectionString("DbConnection");

        }

        /// <inheritdoc/>
        public async Task<string> GetReportsDetails(DateTime? startDate, DateTime? endDate,
             string category,
            string subCategory,
            string itemName,
            bool? isVeg)
        {
           
            try
            {
                string spName = SPNames.SP_GETSOLDITEMWITHPRICEREPORT;


                string connectionString = _connectionString;

                await using (var connection = new SqlConnection(connectionString))
                await using (var command = new SqlCommand(spName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                    command.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
                    command.Parameters.Add("@Category", SqlDbType.VarChar).Value = category;
                    command.Parameters.Add("@SubCategory", SqlDbType.VarChar).Value = subCategory;
                    command.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = itemName;
                    command.Parameters.Add("@Isveg", SqlDbType.Bit).Value = isVeg;


                    //command.CommandTimeout = 100000;

                    using (var adapter = new SqlDataAdapter(command))
                    using (var ds = new DataSet())
                    {
                        adapter.Fill(ds);
                        DataTable soldItemTable = ds.Tables[0];
                        return GenerateExcelusingDatatable(soldItemTable);
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error generating mark report");
                return ex.Message;
            }
        }
        private static string GenerateExcelusingDatatable(DataTable dt)
        {
            try
            {
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
                string filePath = Path.Combine(folderPath, "Report.xlsx");

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Sold Items");

                    int colCount = 1, rowCount = 1;
                    var maxLength = dt.Columns.Count;

                    var titleRange = ws.Range(rowCount, colCount, rowCount, maxLength);
                    // Add title (optional)
                    titleRange.Merge();
                    titleRange.Value = "AVINYA & INDUS SPICES";
                    titleRange.Style.Font.Bold = true;
                    titleRange.Style.Font.FontSize = 16;
                    titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    titleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    titleRange.Style.Border.TopBorder = XLBorderStyleValues.Thick;
                    titleRange.Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                    titleRange.Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                    titleRange.Style.Border.RightBorder = XLBorderStyleValues.Thick;
                    rowCount++;
                    var subtitleRange = ws.Range(rowCount, colCount, rowCount, maxLength);
                    subtitleRange.Merge();
                    subtitleRange.Value = "Sold Item Report";
                    subtitleRange.Style.Font.Bold = true;
                    subtitleRange.Style.Font.FontSize = 12;
                    subtitleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    subtitleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    subtitleRange.Style.Border.TopBorder = XLBorderStyleValues.Thick;
                    subtitleRange.Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                    subtitleRange.Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                    subtitleRange.Style.Border.RightBorder = XLBorderStyleValues.Thick;
                    rowCount++;
                    ws.Cell(1, maxLength).Value = "Sold Item Report";
                    ws.Cell(1, maxLength).Style.Font.Bold = true;
                    ws.Cell(1, maxLength).Style.Font.FontSize = 16;
      
                    // Add column headers with "S.No"
                    int rowStart = 3;
                  
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        ws.Cell(rowStart, i + 1).Value = dt.Columns[i].ColumnName;
                    }

                    // Add rows
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            ws.Cell(rowStart + i + 1, j + 1).Value = dt.Rows[i][j]?.ToString();
                        }
                    }

                    // Auto-adjust columns
                    ws.Columns().AdjustToContents();

                    // Save Excel
                    //filePath = Path.Combine(folderPath, "SoldItemsReport.xlsx");
                    wb.SaveAs(filePath);
                    return filePath;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
