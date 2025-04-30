using AutoMapper;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Interfaces;

namespace RestaurantManagement.Application.Services
{
    /// <summary>
    /// Service class for performing operations on restaurant profiles.
    /// </summary>
    public class RestaurantProfileService : IRestaurantProfileService
    {
        private readonly IRestaurantProfileRepository _restaurantProfileRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantProfileService"/> class.
        /// </summary>
        public RestaurantProfileService(IRestaurantProfileRepository restaurantProfileRepository, IMapper mapper)
        {
            _restaurantProfileRepository = restaurantProfileRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RestaurantProfilesDto>> GetRestaurantProfilesDetails(int? id)
        {
            var restaurantProfiles = await _restaurantProfileRepository.GetRestaurantProfilesDetails(id);
            return _mapper.Map<IEnumerable<RestaurantProfilesDto>>(restaurantProfiles);
        }

        /// <inheritdoc/>
        public async Task UpdateRestaurantProfileDetails(RestaurantProfilesDto restaurantProfileDto)
        {
            var restaurantProfile = _mapper.Map<RestaurantProfiles>(restaurantProfileDto);
            await _restaurantProfileRepository.UpdateRestaurantProfileDetails(restaurantProfile);
        }
    }
}
