using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing operations on restaurant profiles.
    /// </summary>
    public interface IRestaurantProfileService
    {
        /// <summary>
        /// Retrieves restaurant profiles, optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the restaurant profile to retrieve. If not provided, retrieves all profiles.</param>
        /// <returns>
        /// A task that returns a collection of <see cref="RestaurantProfilesDto"/> objects.
        /// </returns>
        Task<IEnumerable<RestaurantProfilesDto>> GetRestaurantProfilesDetails(int? id);

        /// <summary>
        /// Updates an existing restaurant profile.
        /// </summary>
        /// <param name="restaurantProfileDto">The DTO representing the updated restaurant profile.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateRestaurantProfileDetails(RestaurantProfilesDto restaurantProfileDto);
    }
}
