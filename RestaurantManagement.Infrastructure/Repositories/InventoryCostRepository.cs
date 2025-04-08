using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Constants;
using RestaurantManagement.Infrastructure.DatabaseConnection;
using RestaurantManagement.Infrastructure.Interfaces;
using System.Data;
using Dapper;

namespace RestaurantManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on bill.
    /// </summary>
    public class InventoryCostRepository : IInventoryCostRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryCostRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public InventoryCostRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<InventoryCost>> GetInventoryCostsDetails(int? id)
        {
            var spName = SPNames.SP_GETAllINVENTORYCOSTDETAIL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<InventoryCost>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<InventoryCost> InsertInventoryCostDetails(InventoryCost inventoryCosts)
        {
            var spName = SPNames.SP_INSERTCUSTOMERDETAIL; // Name of your stored procedure
                                                                 // Define parameters for the stored procedure
            
            

            var parameters = new
            {
                ItemId = inventoryCosts.ItemId,
                Cost = inventoryCosts.Cost,               
                CreatedBy = inventoryCosts.CreatedBy,

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<InventoryCost>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateInventoryCostDetails(InventoryCost inventoryCosts)
        {
            var spName = SPNames.SP_UPDATECUSTOMERDETAIL; // Update the stored procedure name if necessary
            

            var parameters = new
            {
                Id = inventoryCosts.Id,
                ItemId = inventoryCosts.ItemId,
                Cost = inventoryCosts.Cost,
                ModifiedBy = inventoryCosts.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteInventoryCostDetails(int id)
        {
            var spName = SPNames.SP_DELETECUSTOMERDETAIL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
