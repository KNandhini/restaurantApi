using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Domain.Entities;
using System.Net;

namespace RestaurantManagement.Api.Controllers
{
    /// <summary>
    /// Controller for handling GET and UPDATE operations on restaurant profiles.
    /// </summary>
    [Route("api/restaurant-profile")]
    [ApiController]
    public class RestaurantProfileController : RestaurantManagementControllerBase
    {
        private readonly IRestaurantProfileService _restaurantProfileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantProfileController"/> class.
        /// </summary>
        public RestaurantProfileController(ILogger<RestaurantProfileController> logger, IRestaurantProfileService restaurantProfileService)
            : base(logger)
        {
            _restaurantProfileService = restaurantProfileService;
        }

        /// <summary>
        /// Retrieves restaurant profile details.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RestaurantProfilesDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetRestaurantProfiles()
        {
            _logger.LogInformation("{Method} called", nameof(GetRestaurantProfiles));
            try
            {
                var result = await _restaurantProfileService.GetRestaurantProfilesDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching restaurant profile.");
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates a restaurant profile.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateRestaurantProfile([FromBody] RestaurantProfilesDto restaurantProfileDto)
        {
            _logger.LogInformation("{Method} called", nameof(UpdateRestaurantProfile));

            var existing = await _restaurantProfileService.GetRestaurantProfilesDetails(restaurantProfileDto.Id);
            if (existing == null || !existing.Any())
            {
                return NotFound();
            }

            try
            {
                await _restaurantProfileService.UpdateRestaurantProfileDetails(restaurantProfileDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating restaurant profile.");
                return InternalServerError(ex);
            }
        }
    }
}
