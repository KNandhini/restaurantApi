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
    public class OrderTypeRepository : IOrderTypeRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTypeRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public OrderTypeRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<OrderTypes>> GetOrderTypesDetails(int? id)
        {
            var spName = SPNames.SP_GETAllORDERTYPEMASTER; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<OrderTypes>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<OrderTypes> InsertOrderTypeDetails(OrderTypes orderTypes)
        {
            var spName = SPNames.SP_INSERTORDERTYPEMASTER; // Name of your stored procedure
                                                                 // Define parameters for the stored procedure
            
            

            var parameters = new
            {   
                OrderType=orderTypes.OrderType,
                SubType= orderTypes.SubType,
                CreatedBy = orderTypes.CreatedBy,

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<OrderTypes>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateOrderTypeDetails(OrderTypes orderTypes)
        {
            var spName = SPNames.SP_UPDATEORDERTYPEMASTER; // Update the stored procedure name if necessary
            

            var parameters = new
            {
                Id = orderTypes.Id,
                OrderType = orderTypes.OrderType,
                SubType = orderTypes.SubType,
                ModifiedBy = orderTypes.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteOrderTypeDetails(int id)
        {
            var spName = SPNames.SP_DELETEORDERTYPEMASTER; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
        public async Task ResetPasswordAsync(int id, string orderTypename, string newPassword, string modifiedBy)
        {
            var spName = SPNames.SP_UPDATEPASSWORD; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = id,
                OrderTypeName = orderTypename,
                Password = newPassword,
                ModifiedBy = modifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));

        }
    }
}
