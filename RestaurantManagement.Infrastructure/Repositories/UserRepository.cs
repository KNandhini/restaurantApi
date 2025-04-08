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
    public class UserRepository : IUserRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public UserRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Users>> GetUsersDetails(int? id)
        {
            var spName = SPNames.SP_GETAllUSERMASTER; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Users>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Users> InsertUserDetails(Users users)
        {
            var spName = SPNames.SP_INSERTUSERMASTER; // Name of your stored procedure
                                                                 // Define parameters for the stored procedure
            
            

            var parameters = new
            {   
                Name=users.Name,
                RoleId=users.RoleId,
                PhoneNo=users.PhoneNo,
                Address=users.Address,
                Locality=users.Locality,
                Info=users.Info,
                UserName=users.UserName,
                Password=users.Password,
                CreatedBy = users.CreatedBy,

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Users>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateUserDetails(Users users)
        {
            var spName = SPNames.SP_UPDATEUSERMASTER; // Update the stored procedure name if necessary
            

            var parameters = new
            {
                Id = users.Id,
                Name = users.Name,
                RoleId = users.RoleId,
                PhoneNo = users.PhoneNo,
                Address = users.Address,
                Locality = users.Locality,
                Info = users.Info,
                UserName = users.UserName,
                Password = users.Password,
                ModifiedBy = users.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteUserDetails(int id)
        {
            var spName = SPNames.SP_DELETEUSERMASTER; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
        public async Task ResetPasswordAsync(int id, string username, string newPassword, string modifiedBy)
        {
            var spName = SPNames.SP_UPDATEPASSWORD; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = id,
                UserName = username,
                Password = newPassword,
                ModifiedBy = modifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));

        }
    }
}
