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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public RoleRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Roles>> GetRolesDetails(int? id)
        {
            var spName = SPNames.SP_GETAllROLEMASTER; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Roles>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Roles> InsertRoleDetails(Roles roles)
        {
            var spName = SPNames.SP_INSERTROLEMASTER; // Name of your stored procedure
                                                      // Define parameters for the stored procedure
             var parameters = new
            {
                
                Role = roles.Role,
                CreatedBy = roles.CreatedBy,


            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Roles>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateRoleDetails(Roles roles)
        {
            var spName = SPNames.SP_UPDATEROLEMASTER; // Update the stored procedure name if necessary


            var parameters = new
            {
                Id = roles.Id,
                Role = roles.Role,
                ModifiedBy = roles.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteRoleDetails(int id)
        {
            var spName = SPNames.SP_DELETEROLEMASTER; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
        public async Task ResetPasswordAsync(int id, string rolename, string newPassword, string modifiedBy)
        {
            var spName = SPNames.SP_UPDATEPASSWORD; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = id,
                RoleName = rolename,
                Password = newPassword,
                ModifiedBy = modifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));

        }
    }
}
