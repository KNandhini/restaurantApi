﻿using RestaurantManagement.Domain.Entities;
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
    public class BillRepository : IBillRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="BillRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public BillRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Billings>> GetBillsDetails(int? id)
        {
            var spName = SPNames.SP_GETAllBILLINGDETAIL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Billings>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Billings> InsertBillDetails(Billings bill)
        {
            var spName = SPNames.SP_INSERTBILLINGDETAIL; // Name of your stored procedure
                                                                 // Define parameters for the stored procedure
            
            

            var parameters = new
            {
                OrderId = bill.OrderId,
                TableId = bill.TableId,
                DiscountId = bill.DiscountId,
                CustomerName = bill.CustomerName,
                CustomerAddress = bill.CustomerAddress,
                CustomerPhoneNo = bill.CustomerPhoneNo,
                CustomerLocality = bill.CustomerLocality,
                CustomerInfo = bill.CustomerInfo,
                IsParcelRequired = bill.IsParcelRequired,
                ParcelAmount=bill.ParcelAmount,
                NoofPerson=bill.NoofPerson,
                ServiceCharge =bill.ServiceCharge,
                DiscountAmount=bill.DiscountAmount,
                NetAmount=bill.NetAmount,
                SubTotal=bill.SubTotal,
                RoundOff=bill.RoundOff,
                Sgst=bill.Sgst,
                Cgst = bill.Cgst,
                GrandTotal=bill.GrandTotal,
                CreatedBy=bill.CreatedBy

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Billings>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateBillDetails(BillingUpdate bill)
        {
            var spName = SPNames.SP_UPDATEBILLPAIDSTATUS; // Update the stored procedure name if necessary
            

            var parameters = new
            {
                OrderId = bill.OrderId,
               PaymentMode=bill.PaymentMode,
                ModifiedBy = bill.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteBillDetails(int id)
        {
            var spName = SPNames.SP_DELETEBILLINGDETAIL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
