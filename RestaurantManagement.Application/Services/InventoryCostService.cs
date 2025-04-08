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
    /// Service class for performing CRUD operations on inventoryCosts.
    /// </summary>
    public class InventoryCostService : IInventoryCostService
    {
        private readonly IInventoryCostRepository _inventoryCostRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryCostService"/> class.
        /// </summary>
        /// <param name="InventoryCostRepository">The repository for accessing InventoryCostDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public InventoryCostService(IInventoryCostRepository inventoryCostRepository, IMapper mapper)
        {
            _inventoryCostRepository = inventoryCostRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<InventoryCostDto>> GetInventoryCostsDetails(int? id)
        {
            var InventoryCosts = await _inventoryCostRepository.GetInventoryCostsDetails(id);

            var InventoryCostDetails = _mapper.Map<IEnumerable<InventoryCostDto>>(InventoryCosts);
            return InventoryCostDetails;
        }
        /// <inheritdoc/>
        public async Task<InventoryCostDto> InsertInventoryCostDetails(InventoryCostDto inventoryCostDto)
        {

            var InventoryCost = _mapper.Map<InventoryCost>(inventoryCostDto);
            var insertedData = await _inventoryCostRepository.InsertInventoryCostDetails(InventoryCost);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("InventoryCost insertion failed.");
            }
            return _mapper.Map<InventoryCostDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateInventoryCostDetails(InventoryCostDto inventoryCostDto)
        {
            var InventoryCost = _mapper.Map<InventoryCost>(inventoryCostDto);
            await _inventoryCostRepository.UpdateInventoryCostDetails(InventoryCost);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteInventoryCostDetails(int id)
        {
            return await _inventoryCostRepository.DeleteInventoryCostDetails(id);
        }
        
        
    }
}
