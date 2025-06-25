using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Constants;
using RestaurantManagement.Infrastructure.DatabaseConnection;
using RestaurantManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Repositories
{/// <summary>
 /// Repository class for performing CRUD operations on TableDetails.
 /// </summary>
    public class TableDetailsRepository : ITableDetailsRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableDetailsRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public TableDetailsRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TableDetails>> GetTableDetails(int? id)
        {
            var spName = SPNames.SP_GETALLTABLEDETAILS; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<TableDetails>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<IEnumerable<TableMappingDetails>> GetMappingTableDetails(int? id)
        {
            var spName = SPNames.SP_GETALLTABLEMAPPEDDETAILS; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<TableMappingDetails>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }



        public async Task<TableDetails> InsertTableDetails(TableDetails TableDetails)
        {
            var spName = SPNames.SP_INSERTTABLEDETAILS; // Name of your stored procedure
                                                             // Define parameters for the stored procedure



            var parameters = new
            {
                TableId = TableDetails.TableId,
                TableCode= TableDetails.TableCode,
                NoofSeats=TableDetails.NoofSeats,
                CreatedBy = TableDetails.CreatedBy,


            };

            // Execute the stored procedure and retrieve the inserted data
            await _db.Connection.ExecuteAsync(
    spName,
    parameters,
    commandType: CommandType.StoredProcedure
);

            return TableDetails;


        }
        /// <inheritdoc/>
        public async Task UpdateTableDetails(TableDetails TableDetails)
        {
            var spName = SPNames.SP_UPDATETABLEDETAILS; // Update the stored procedure name if necessary


            var parameters = new
            {
                Id = TableDetails.Id,
                TableId = TableDetails.TableId,
                TableCode = TableDetails.TableCode,
                NoofSeats = TableDetails.NoofSeats,
                ModifiedBy = TableDetails.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteTableDetails(int id)
        {
            var spName = SPNames.SP_DELETETABLEDETAILS; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
