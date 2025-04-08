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
    /// Service class for performing CRUD operations on inventorys.
    /// </summary>
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="InventoryRepository">The repository for accessing InventoryDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<InventoryDto>> GetInventorysDetails(int? id)
        {
            var Inventorys = await _inventoryRepository.GetInventorysDetails(id);

            var InventoryDetails = _mapper.Map<IEnumerable<InventoryDto>>(Inventorys);
            return InventoryDetails;
        }
        /// <inheritdoc/>
        public async Task<InventoryDto> InsertInventoryDetails(InventoryDto inventoryDto)
        {

            var Inventory = _mapper.Map<Inventorys>(inventoryDto);
            var insertedData = await _inventoryRepository.InsertInventoryDetails(Inventory);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("Inventory insertion failed.");
            }
            return _mapper.Map<InventoryDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateInventoryDetails(InventoryDto inventoryDto)
        {
            var Inventory = _mapper.Map<Inventorys>(inventoryDto);
            await _inventoryRepository.UpdateInventoryDetails(Inventory);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteInventoryDetails(int id)
        {
            return await _inventoryRepository.DeleteInventoryDetails(id);
        }
        
        
    }
}
