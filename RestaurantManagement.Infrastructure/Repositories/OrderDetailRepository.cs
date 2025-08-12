using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Constants;
using RestaurantManagement.Infrastructure.DatabaseConnection;
using RestaurantManagement.Infrastructure.Interfaces;
using System.Data;
using Dapper;
using System.Reflection;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text.Json;
using DocumentFormat.OpenXml.Spreadsheet;

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
        public async Task<OrderDetail> GetOrderDetailsDetails(int? id)
        {
            OrderDetail? order = null;
            var spName = SPNames.SP_GETORDERITEMTRANSACTION; // Update the stored procedure name if necessary
            
            var conn = _db.Connection as DbConnection;
            if (conn == null)
                throw new InvalidOperationException("The connection must be of type DbConnection.");

            await conn.OpenAsync();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;

                var param = cmd.CreateParameter();
                param.ParameterName = "@id";
                param.Value = id.HasValue ? (object)id.Value : DBNull.Value;

                cmd.Parameters.Add(param);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    var itemDetails = new List<OrderItem>();

                    while (await reader.ReadAsync())
                    {
                        if (order == null)
                        {
                            order = new OrderDetail
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                OrderId = Convert.ToInt32(reader["OrderId"]),
                                WaiterId = Convert.ToInt32(reader["WaiterId"]),
                                OrderTypeId = Convert.ToInt32(reader["OrderTypeId"]),
                                TableId = Convert.ToInt32(reader["TableId"]),
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                CreatedBy = reader["CreatedBy"]?.ToString(),
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                ModifiedBy = reader["ModifiedBy"] == DBNull.Value? "" : reader["ModifiedBy"].ToString(),
                                ModifiedDate = reader["ModifiedDate"] == DBNull.Value  ? DateTime.UtcNow  : Convert.ToDateTime(reader["ModifiedDate"]),
                                TableCatagory = reader["tableCatagory"]?.ToString(),
                                TableCode = reader["TableCode"]?.ToString(),
                                CustomerName = reader["CustomerName"]?.ToString(),
                                CustomerAddress = reader["CustomerAddress"]?.ToString(),
                                CustomerPhoneNo = reader["CustomerPhoneNo"]?.ToString(),
                                CustomerLocality = reader["CustomerLocality"]?.ToString(),
                                CustomerInfo = reader["CustomerInfo"]?.ToString(),
                                OrderType = reader["OrderType"]?.ToString(),
                                OrderSubType = reader["OrderSubType"]?.ToString(),
                                WaiterName = reader["WaiterName"]?.ToString(),
                                BillId = Convert.ToInt32(reader["BillId"]),
                                DiscountId= Convert.ToInt32(reader["DiscountId"]),
                                PaymentMode= reader["PaymentMode"]?.ToString(),
                                // IsParcelRequired= Convert.ToBoolean(reader["IsParcelRequired"]),
                               NoofPerson = Convert.ToInt32(reader["NoofPerson"]),
                                ParcelAmount =  Convert.ToDecimal(reader["ParcelAmount"]),
                                ServiceCharge= Convert.ToDecimal(reader["ServiceCharge"]),
                                DiscountAmount= Convert.ToDecimal(reader["DiscountAmount"]),
                                NetAmount= Convert.ToDecimal(reader["NetAmount"]),
                                Cgst= Convert.ToDecimal(reader["Cgst"]),
                                Sgst= Convert.ToDecimal(reader["Sgst"]),
                                RoundOff = Convert.ToDecimal(reader["RoundOff"]),
                                SubTotal = Convert.ToDecimal(reader["SubTotal"]),

                                GrandTotal = Convert.ToDecimal(reader["GrandTotal"]),
                                IsPaymentDone= Convert.ToBoolean(reader["IsPaymentDone"]),
                                ItemDetails = new List<OrderItem>(),
                                TokenNumbers = reader["TokenNumbers"]?.ToString() 
                            };
                        }

                        var item = new OrderItem
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            OrderId = Convert.ToInt32(reader["orderId"]),
                            ItemId = Convert.ToInt32(reader["itemId"]),
                            ItemCode = reader["itemCode"]?.ToString(),
                            ItemName = reader["itemName"]?.ToString(),
                            ItemComment = reader["itemComment"]?.ToString(),
                            Qty = Convert.ToInt32(reader["qty"]),
                            Price = Convert.ToDecimal(reader["price"]),
                            Status = (reader["status"])?.ToString(),
                           
                            IsActive = Convert.ToBoolean(reader["isActive"]),
                           
                        };

                        order.ItemDetails.Add(item);
                    }
                }
            }

             return order;
        }

        public async Task<OrderDetail> InsertOrderDetails(OrderDetail orderDetails)
        {
            var spNameInsertOrderDetails = SPNames.SP_INSERTORDERDETAIL; // Name of your stored procedure
                                                                         // Define parameters for the stored procedure
          //  var spNameInsertOrderItems = SPNames.SP_INSERTORDERDETAIL;
           // OrderDetail insertedData = new OrderDetail();
            string orderItemsJson = JsonSerializer.Serialize(orderDetails.ItemDetails);
         //   var sendToDB = new ArrayList();
         
                var parameters = new
                {
                    CustomerName = orderDetails.CustomerName,
                    CustomerAddress = orderDetails.CustomerAddress,
                    CustomerPhoneNo = orderDetails.CustomerPhoneNo,
                    CustomerLocality = orderDetails.CustomerLocality,
                    CustomerInfo =orderDetails.CustomerInfo,
                    OrderId =orderDetails.OrderId,
                    OrderItems =orderItemsJson,
                    SeatId =orderDetails.SeatId,
                    TableId = orderDetails.TableId,
                    OrderType = orderDetails.OrderType,
                    WaiterId = orderDetails.WaiterId,
                    CreatedBy = orderDetails.CreatedBy,
                };

                int? insertedData = await _db.Connection.QuerySingleOrDefaultAsync<int?>(
                   spNameInsertOrderDetails,
                   parameters,
                   commandType: CommandType.StoredProcedure
                );



            orderDetails.OrderId = insertedData??0;
                 
           

            //foreach (var item in orderDetails.ItemDetails)
            //{
            //    sendToDB.Add(
            //        new
            //        {
            //            OrderId = orderDetails?.OrderId,
            //            ItemId = item.ItemId,
            //            Qty = item.Qty,
            //            Price = item.Price,
            //            IsSave = item.IsSave,
            //            IsSavePrint=item.IsSavePrint,
            //            IsSaveEBill=item.IsSaveEBill,
            //            IsHold=item.IsHold,
            //            IsKOT=item.IsKOT,
            //            IsKOTPrint=item.IsKOTPrint,
            //            IsFoodReceived=item.IsFoodReceived,
            //            CreatedBy = item.CreatedBy,
                       
            //        });

            //}
            // await Task.Factory.StartNew(() =>
            //    _db.Connection.Execute(spNameInsertOrderItems, sendToDB.ToArray(), commandType: CommandType.StoredProcedure));

            return orderDetails;


        }
        /// <inheritdoc/>
        public async Task UpdateOrderDetailDetails(List<UpdateFoodReceivedRequest> orderDetails)
        {
            var spName = SPNames.SP_UPDATEISFOODRECEIVEDBYITEM; // Update the stored procedure name if necessary


            /* var parameters = new
             {
                 Id=orderDetails.Id,
                 OrderId = orderDetails.OrderId,
                 IsFoodReceived = orderDetails.IsFoodReceived,
                 IsCheckOut = orderDetails.IsCheckOut,
                 ModifiedBy = orderDetails.ModifiedBy,

             };
            */
            // Serialize the list of FoodItem to JSON
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // ensures keys are camelCase if needed
            };

            string itemsJson = JsonSerializer.Serialize(orderDetails, jsonOptions);

            var parameters = new
            {
                CheckoutItems = itemsJson  // must match @CheckoutItems in your SP
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
