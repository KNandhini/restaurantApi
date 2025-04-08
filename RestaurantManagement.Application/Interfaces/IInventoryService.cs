using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on Inventorys.
    /// </summary>
    public interface IInventoryService
    {/// <summary>
     /// Retrieves Inventorys optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the InventoryDto to retrieve. If not provided, retrieves all Inventorys.</param>
     /// <returns>
     /// The task result contains a collection of InventoryDto DTOs. if successful, or null if no Inventorys match the provided identifier.
     /// </returns>
        Task<IEnumerable<InventoryDto>> GetInventorysDetails(int? id);
        /// <summary>
        /// Inserts a new InventoryDto.
        /// </summary>
        /// <param name="inventoryDto">The DTO representing the InventoryDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<InventoryDto> InsertInventoryDetails(InventoryDto inventoryDto);

        /// <summary>
        /// Updates an existing InventoryDto.
        /// </summary>
        /// <param name="inventoryDto">The DTO representing the updated InventoryDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateInventoryDetails(InventoryDto inventoryDto);
        /// <summary>
        /// Deletes a InventoryDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the InventoryDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteInventoryDetails(int id);
    }
}