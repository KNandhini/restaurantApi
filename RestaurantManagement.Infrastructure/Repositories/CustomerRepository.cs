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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public CustomerRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Customers>> GetCustomersDetails(int? id)
        {
            var spName = SPNames.SP_GETAllCUSTOMERDETAIL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Customers>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Customers> InsertCustomerDetails(Customers customers)
        {
            var spName = SPNames.SP_INSERTCUSTOMERDETAIL; // Name of your stored procedure
                                                                 // Define parameters for the stored procedure
            
            

            var parameters = new
            {   
                Name=customers.Name,
                PhoneNo=customers.PhoneNo,
                Address=customers.Address,
                Locality=customers.Locality,
                Info=customers.Info,
                CreatedBy = customers.CreatedBy,

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Customers>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateCustomerDetails(Customers customers)
        {
            var spName = SPNames.SP_UPDATECUSTOMERDETAIL; // Update the stored procedure name if necessary
            

            var parameters = new
            {
                Id = customers.Id,
                Name = customers.Name,
                PhoneNo = customers.PhoneNo,
                Address = customers.Address,
                Locality = customers.Locality,
                Info = customers.Info,
                ModifiedBy = customers.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteCustomerDetails(int id)
        {
            var spName = SPNames.SP_DELETECUSTOMERDETAIL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }

        public async Task<IEnumerable<Customers>> GetCustomerByPhoneNumber(string mobileNo)
        {
            var spName = SPNames.SP_GETAllCUSTOMERBYPHONE; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Customers>(spName,
                new { MobileNo = mobileNo }, commandType: CommandType.StoredProcedure).ToList());
        }
    }
}
