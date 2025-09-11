using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Constants;
using RestaurantManagement.Infrastructure.DatabaseConnection;
using RestaurantManagement.Infrastructure.Interfaces;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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
        public async Task<object> GetReportsDetails(string reportType, DateTime? startDate, DateTime? endDate,
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
                    command.Parameters.AddWithValue("@ReportType", string.IsNullOrWhiteSpace(reportType) ? (object)DBNull.Value : reportType.Trim()); command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@Category", string.IsNullOrWhiteSpace(category) ? (object)DBNull.Value : category.Trim());
                    command.Parameters.AddWithValue("@SubCategory", string.IsNullOrWhiteSpace(subCategory) ? (object)DBNull.Value : subCategory.Trim());
                    command.Parameters.AddWithValue("@ItemName", string.IsNullOrWhiteSpace(itemName) ? (object)DBNull.Value : itemName.Trim());
                    command.Parameters.AddWithValue("@Isveg", isVeg ?? (object)DBNull.Value);


                    //command.CommandTimeout = 100000;

                    using (var adapter = new SqlDataAdapter(command))
                    using (var ds = new DataSet())
                    {
                        adapter.Fill(ds);
                        DataTable soldItemTable = ds.Tables[0];

                        if (reportType?.Trim().ToLower() == "view")
                        {
                            // Convert DataTable → List of dictionary for JSON
                            var list = soldItemTable.AsEnumerable()
                                .Select(row => soldItemTable.Columns.Cast<DataColumn>()
                                    .ToDictionary(col => col.ColumnName, col => row[col]))
                                .ToList();

                            return list;
                        }
                        return GenerateExcelusingDatatable(soldItemTable,reportType);
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error generating mark report");
                return ex.Message;
            }
        }
        /* private static string GenerateExcelusingDatatable(DataTable dt, string reportType)
         {
             try
             {
                 string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
                 string filePath = Path.Combine(folderPath, "Report.xlsx");

                 using (XLWorkbook wb = new XLWorkbook())
                 {
                     var ws = wb.Worksheets.Add("Sold Items");

                     int colCount = 1, rowCount = 1;
                     var colmaxLength = dt.Columns.Count;
                     var rowmaxLength = dt.Rows.Count+3;

                     var titleRange = ws.Range(rowCount, colCount, rowCount, colmaxLength);
                     // Add title (optional)
                     titleRange.Merge();
                     titleRange.Value = "AVINYA & INDUS SPICES";
                     titleRange.Style.Font.Bold = true;
                     titleRange.Style.Font.FontSize = 16;

                     rowCount++;

                     string subtitleText = "Report";
                     if (!string.IsNullOrWhiteSpace(reportType))
                     {
                         if (reportType.Trim().ToLower() == "item")
                             subtitleText = "Sold Item Report";
                         else if (reportType.Trim().ToLower() == "sales")
                             subtitleText = "Sold Sales Report";
                     }
                     var subtitleRange = ws.Range(rowCount, colCount, rowCount, colmaxLength);
                     subtitleRange.Merge();
                     subtitleRange.Value = subtitleText; 
                     subtitleRange.Style.Font.Bold = true;
                     subtitleRange.Style.Font.FontSize = 16;

                     rowCount++;


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
                     if (reportType.Trim().ToLower() == "sales")
                     {
                         string[] columnsToTotal = new[]
                         {
                         "No of Person", "Parcel Amount", "Sub Total", "Discount Amount","Net Amount", "CGST", "SGST", "Grand Total"
     };

                         int totalRowIndex = dt.Rows.Count + rowStart + 1;

                         int startTotalCol = dt.Columns.IndexOf("No of Person"); 

                         if (startTotalCol > 1)
                         {
                             ws.Range(totalRowIndex, 1, totalRowIndex, startTotalCol).Merge();
                             ws.Cell(totalRowIndex, 1).Value = "TOTAL";
                             ws.Cell(totalRowIndex, 1).Style.Font.Bold = true;
                             ws.Cell(totalRowIndex, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                         }

                         // ➕ Add totals from "No of Person" column onward
                         foreach (DataColumn column in dt.Columns)
                         {
                             if (columnsToTotal.Contains(column.ColumnName))
                             {
                                 double total = 0;
                                 foreach (DataRow row in dt.Rows)
                                 {
                                     if (double.TryParse(row[column.ColumnName]?.ToString(), out double value))
                                         total += value;
                                 }

                                 int currentCol = dt.Columns.IndexOf(column) + 1;
                                 ws.Cell(totalRowIndex, currentCol).Value = total;
                                 ws.Cell(totalRowIndex, currentCol).Style.Font.Bold = true;
                             }
                         }


                         var totalRow = ws.Range(totalRowIndex, 1, totalRowIndex, dt.Columns.Count);
                         totalRow.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                         totalRow.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                         totalRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                     }

                     // Auto-adjust columns
                     ws.Columns().AdjustToContents();
                     var maintitleRange = ws.Range(rowCount, colCount, rowmaxLength, colmaxLength);
                     maintitleRange.Style.Border.TopBorder = XLBorderStyleValues.Thick;
                     maintitleRange.Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                     maintitleRange.Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                     maintitleRange.Style.Border.RightBorder = XLBorderStyleValues.Thick;
                     var usedRange = ws.RangeUsed(); // Gets the full used range of the worksheet

                     // Apply border to all cells in the used range
                     usedRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                     usedRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                     usedRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                     usedRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;


                     subtitleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                     subtitleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                     subtitleRange.Style.Border.TopBorder = XLBorderStyleValues.Thick;
                     subtitleRange.Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                     subtitleRange.Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                     subtitleRange.Style.Border.RightBorder = XLBorderStyleValues.Thick;
                     titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                     titleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                     titleRange.Style.Border.TopBorder = XLBorderStyleValues.Thick;
                     titleRange.Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                     titleRange.Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                     titleRange.Style.Border.RightBorder = XLBorderStyleValues.Thick;
                     // Save Excel
                     //filePath = Path.Combine(folderPath, "sp_GetSoldItemwithPriceReport.xlsx");
                     wb.SaveAs(filePath);
                     return filePath;
                 }
             }
             catch (Exception ex)
             {
                 return ex.Message;
             }
         }*/
        private static string GenerateExcelusingDatatable(DataTable dt, string reportType)
        {
            try
            {
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, "Report.xlsx");

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Sold Items");

                    int colCount = 1, rowCount = 1;
                    //   var colmaxLength = dt.Columns.Count + 2; // since "Mode of Payment" expands to 3 cols

                    int colmaxLength = 0;

                    // 🔍 Dynamically calculate correct column count (handles "Mode of Payment" case)
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName == "Mode of Payment")
                            colmaxLength += 3; // Cash, Card, UPI
                        else
                            colmaxLength += 1;
                    }

                    var rowmaxLength = dt.Rows.Count + 3;

                    // 🔹 Title
                    var titleRange = ws.Range(rowCount, colCount, rowCount, colmaxLength);
                    titleRange.Merge();
                    titleRange.Value = "AVINYA & INDUS SPICES";
                    titleRange.Style.Font.Bold = true;
                    titleRange.Style.Font.FontSize = 16;
                    titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    titleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    titleRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                    rowCount++;

                    // 🔹 Subtitle
                    string subtitleText = "Report";
                    if (!string.IsNullOrWhiteSpace(reportType))
                    {
                        if (reportType.Trim().ToLower() == "item")
                            subtitleText = "Sold Item Report";
                        else if (reportType.Trim().ToLower() == "sales")
                            subtitleText = "Sold Sales Report";
                    }

                    var subtitleRange = ws.Range(rowCount, colCount, rowCount, colmaxLength);
                    subtitleRange.Merge();
                    subtitleRange.Value = subtitleText;
                    subtitleRange.Style.Font.Bold = true;
                    subtitleRange.Style.Font.FontSize = 16;
                    subtitleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    subtitleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    subtitleRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                    rowCount++;

                    // 🔹 Column headers
                    int rowStart = 3;
                    int excelCol = 1;

                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName == "Mode of Payment")
                        {
                            ws.Cell(rowStart, excelCol).Value = "Cash";
                            ws.Cell(rowStart, excelCol + 1).Value = "Card";
                            ws.Cell(rowStart, excelCol + 2).Value = "UPI";
                            excelCol += 3;
                        }
                        else
                        {
                            ws.Cell(rowStart, excelCol).Value = column.ColumnName;
                            excelCol++;
                        }
                    }

                    // 🔹 Fill rows
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        excelCol = 1;

                        foreach (DataColumn column in dt.Columns)
                        {
                            //Here’s the corrected section of your code:

                            if (column.ColumnName == "Mode of Payment")
                            {
                                string cashVal = "-", cardVal = "-", upiVal = "-";
                                string paymentValue = dt.Rows[i][column]?.ToString()?.Trim();

                                // ✅ Always read Sub Total
                                double.TryParse(dt.Rows[i]["Sub Total"]?.ToString(), out double subTotal);

                                if (!string.IsNullOrWhiteSpace(paymentValue))
                                {
                                    if (paymentValue.Contains(":")) // Case: "Cash:100, Upi:58, Card:50"
                                    {
                                        var parts = paymentValue.Split(',');
                                        foreach (var part in parts)
                                        {
                                            var keyValue = part.Split(':');
                                            if (keyValue.Length == 2)
                                            {
                                                string key = keyValue[0].Trim().ToLower();
                                                string rawVal = keyValue[1].Replace("'", "").Trim();
                                                if (double.TryParse(rawVal, out double val))
                                                {
                                                    if (key == "cash") cashVal = val.ToString();
                                                    else if (key == "card") cardVal = val.ToString();
                                                    else if (key == "upi") upiVal = val.ToString();
                                                }
                                            }
                                        }
                                    }
                                    else // Case: only "Cash" or "Card" or "UPI"
                                    {
                                        string key = paymentValue.ToLower();
                                        if (key == "cash") cashVal = subTotal.ToString();
                                        else if (key == "card") cardVal = subTotal.ToString();
                                        else if (key == "upi") upiVal = subTotal.ToString();
                                    }
                                }

                                // ✅ Assign strings directly
                                ws.Cell(rowStart + i + 1, excelCol).Value = cashVal;
                                ws.Cell(rowStart + i + 1, excelCol + 1).Value = cardVal;
                                ws.Cell(rowStart + i + 1, excelCol + 2).Value = upiVal;

                                excelCol += 3;
                            }
                            /* else
                             {
                                 //ws.Cell(rowStart + i + 1, excelCol).Value = dt.Rows[i][column]?.ToString();
                                 // ✅ Handle BillDate column separately
                                 if (column.ColumnName.Equals("Bill Date", StringComparison.OrdinalIgnoreCase))
                                 {

                                     if (DateTime.TryParse(dt.Rows[i][column]?.ToString(), out DateTime billDate))
                                     {
                                         // ✅ Assign DateTime and apply number format
                                         var cell = ws.Cell(rowStart + i + 1, excelCol);
                                         cell.Value = billDate;
                                         cell.Style.DateFormat.Format = "dd-MM-yyyy";
                                     }
                                     else
                                     {
                                         ws.Cell(rowStart + i + 1, excelCol).Value = dt.Rows[i][column]?.ToString();
                                     }
                                 }
                                 else
                                 {
                                     ws.Cell(rowStart + i + 1, excelCol).Value = dt.Rows[i][column]?.ToString();
                                 }
                                 excelCol++;
                             }*/
                            else
                            {
                                var cell = ws.Cell(rowStart + i + 1, excelCol);

                                if (column.ColumnName.Equals("Bill Date", StringComparison.OrdinalIgnoreCase))
                                {
                                    // ✅ Format the date into 12-hour format with AM/PM if it's a valid DateTime
                                    var rawValue = dt.Rows[i][column]?.ToString();
                                    if (DateTime.TryParse(rawValue, out DateTime billDate))
                                    {
                                        cell.Value = billDate.ToString("dd-MM-yyyy hh:mm:ss tt");
                                    }
                                    else
                                    {
                                        // If parsing fails, just print the raw value
                                        cell.Value = rawValue;
                                    }
                                }
                                else
                                {
                                    cell.Value = dt.Rows[i][column]?.ToString();
                                }
                                excelCol++;
                            }
                        }
                    }

                    // 🔹 Totals for Sales Report
                    if (reportType.Trim().ToLower() == "sales")
                    {
                        string[] columnsToTotal = new[]
                        {
                    "No of Person", "Parcel Amount", "Sub Total", "Discount Amount",
                    "Net Amount", "CGST", "SGST", "Grand Total", "Cash", "Card", "UPI"
                };

                        int totalRowIndex = dt.Rows.Count + rowStart + 1;
                        ws.Cell(totalRowIndex, 1).Value = "TOTAL";
                        ws.Cell(totalRowIndex, 1).Style.Font.Bold = true;
                        ws.Cell(totalRowIndex, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        foreach (IXLCell headerCell in ws.Row(rowStart).CellsUsed())
                        {
                            string colName = headerCell.Value.ToString();
                            if (columnsToTotal.Contains(colName))
                            {
                                int colIndex = headerCell.Address.ColumnNumber;
                                double total = 0;

                                for (int r = rowStart + 1; r <= rowStart + dt.Rows.Count; r++)
                                {
                                    double.TryParse(ws.Cell(r, colIndex).Value.ToString(), out double val);
                                    total += val;
                                }

                                ws.Cell(totalRowIndex, colIndex).Value = total;
                                ws.Cell(totalRowIndex, colIndex).Style.Font.Bold = true;
                            }
                        }

                        var totalRow = ws.Range(totalRowIndex, 1, totalRowIndex, colmaxLength);
                        totalRow.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        totalRow.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                        totalRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                    }

                    // 🔹 Formatting
                    ws.Columns().AdjustToContents();
                    var usedRange = ws.RangeUsed();
                    usedRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    usedRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    usedRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    usedRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;

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
