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
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public InventoryRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Inventorys>> GetInventorysDetails(int? id)
        {
            var spName = SPNames.SP_GETAllINVENTORYDETAIL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Inventorys>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Inventorys> InsertInventoryDetails(Inventorys inventorys)
        {
            var spName = SPNames.SP_INSERTINVENTORYDETAIL; // Name of your stored procedure
                                                                 // Define parameters for the stored procedure
            
            

            var parameters = new
            {
                ItemCode = inventorys.ItemCode,
                Category = inventorys.Category,
                SubCategory = inventorys.SubCategory,
                ItemName = inventorys.ItemName,
                IsVeg = inventorys.IsVeg,
                Description = inventorys.Description,
                CreatedBy = inventorys.CreatedBy,

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Inventorys>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateInventoryDetails(Inventorys inventorys)
        {
            var spName = SPNames.SP_UPDATEINVENTORYDETAIL; // Update the stored procedure name if necessary
            

            var parameters = new
            {
                Id = inventorys.Id,
                ItemCode = inventorys.ItemCode,
                Category = inventorys.Category,
                SubCategory = inventorys.SubCategory,
                ItemName = inventorys.ItemName,
                IsVeg = inventorys.IsVeg,
                Description = inventorys.Description,
                ModifiedBy = inventorys.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteInventoryDetails(int id)
        {
            var spName = SPNames.SP_DELETEINVENTORYDETAIL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
