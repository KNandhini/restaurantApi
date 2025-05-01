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
    public class RestaurantProfileRepository : IRestaurantProfileRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantProfileRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public RestaurantProfileRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<RestaurantProfiles>> GetRestaurantProfilesDetails(int? id)
        {
            var spName = SPNames.SP_GETAllRESTAURANTPROFILEMASTER;

            

            // No parameters — this matches your current SP signature
            return await Task.Factory.StartNew(() =>
                _db.Connection.Query<RestaurantProfiles>(spName, commandType: CommandType.StoredProcedure).ToList());
        }



        /// <inheritdoc/>
        public async Task UpdateRestaurantProfileDetails(RestaurantProfiles restaurantProfile)
        {
            var spName = SPNames.SP_UPDATERESTAURANTPROFILEMASTER; // Update the stored procedure name if necessary


            var parameters = new
            {
                Id = restaurantProfile.Id,
                RestaurantName = restaurantProfile.RestaurantName,
                Email = restaurantProfile.Email,
                Phone = restaurantProfile.Phone,
                Address = restaurantProfile.Address,
                City = restaurantProfile.City,
                State = restaurantProfile.State,
                Country = restaurantProfile.Country,
                ZipCode = restaurantProfile.ZipCode,
                GSTNo = restaurantProfile.GSTNo,
                CGST = restaurantProfile.CGST,   
                SGST = restaurantProfile.SGST, 
                ModifiedBy = restaurantProfile.ModifiedBy
            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

       
    }
}
