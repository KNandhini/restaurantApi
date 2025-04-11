using AutoMapper;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on discounts.
    /// </summary>
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountService"/> class.
        /// </summary>
        /// <param name="DiscountRepository">The repository for accessing DiscountDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<DiscountDto>> GetDiscountsDetails(int? id)
        {
            var Discounts = await _discountRepository.GetDiscountsDetails(id);

            var DiscountDetails = _mapper.Map<IEnumerable<DiscountDto>>(Discounts);
            return DiscountDetails;
        }
        /// <inheritdoc/>
        public async Task<DiscountDto> InsertDiscountDetails(DiscountDto discountDto)
        {

            var Discount = _mapper.Map<Discounts>(discountDto);
            var insertedData = await _discountRepository.InsertDiscountDetails(Discount);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("Discount insertion failed.");
            }
            return _mapper.Map<DiscountDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateDiscountDetails(DiscountDto discountDto)
        {
            var Discount = _mapper.Map<Discounts>(discountDto);
            await _discountRepository.UpdateDiscountDetails(Discount);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteDiscountDetails(int id)
        {
            return await _discountRepository.DeleteDiscountDetails(id);
        }


    }
}
