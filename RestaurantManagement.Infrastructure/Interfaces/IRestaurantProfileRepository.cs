using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on RestaurantProfiles.
    /// </summary>
    public interface IRestaurantProfileRepository
    { /// <summary>
      /// Retrieves RestaurantProfiles optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the RestaurantProfiles to retrieve. If not provided, retrieves all RestaurantProfiless.</param>
      /// <returns>
      /// The task result contains a collection of RestaurantProfiles if successful, or null if no RestaurantProfiless match the provided identifier.
      /// </returns>
        Task<IEnumerable<RestaurantProfiles>> GetRestaurantProfilesDetails(int? id);
        
        /// <summary>
        /// Updates an existing RestaurantProfiles.
        /// </summary>
        /// <param name="restaurantProfiles">The RestaurantProfiles to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateRestaurantProfileDetails(RestaurantProfiles restaurantProfiles);
        /// <summary>
        /// Deletes a RestaurantProfiles by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the RestaurantProfiles to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
       
    }
}
