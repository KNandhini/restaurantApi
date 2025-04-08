using AutoMapper;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Domain.Entities;

namespace RestaurantManagement.Application.Mappings
{
    /// <summary>
    /// Represents a AutoMapper mapping profile for mapping between entities and DTOs.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Define mappings between Brand and BrandDto

            CreateMap<Billings, BillingDto>().ReverseMap();
            CreateMap<Customers, CustomerDto>().ReverseMap();
            CreateMap<Inventorys, InventoryDto > ().ReverseMap();
            CreateMap<InventoryCost, InventoryCostDto>().ReverseMap();
            CreateMap<Users, UserDto>().ReverseMap();
        }
    }
}
