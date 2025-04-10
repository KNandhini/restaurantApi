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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public OrderDetailRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsDetails(int? id)
        {
            var spName = SPNames.SP_GETAllORDERDETAIL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<OrderDetail>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<OrderDetail> InsertOrderDetailDetails(OrderDetail orderDetails)
        {
            var spName = SPNames.SP_INSERTORDERDETAIL; // Name of your stored procedure
                                                                 // Define parameters for the stored procedure
            
            

            var parameters = new
            {
                
                CustomerId = orderDetails.CustomerId,
                TableId = orderDetails.TableId,
                OrderType = orderDetails.OrderType,
                WaiterId = orderDetails.WaiterId,
                CreatedBy = orderDetails.CreatedBy,

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<OrderDetail>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateOrderDetailDetails(OrderDetail orderDetails)
        {
            var spName = SPNames.SP_UPDATEORDERDETAIL; // Update the stored procedure name if necessary
            

            var parameters = new
            {
                CustomerId = orderDetails.CustomerId,
                TableId = orderDetails.TableId,
                OrderType = orderDetails.OrderType,
                WaiterId = orderDetails.WaiterId,
                ModifiedBy = orderDetails.ModifiedBy,

            };


            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteOrderDetailDetails(int id)
        {
            var spName = SPNames.SP_DELETEORDERDETAIL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
