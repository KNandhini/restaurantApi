using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on InventoryCosts.
    /// </summary>
    public interface IInventoryCostService
    {/// <summary>
     /// Retrieves InventoryCosts optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the InventoryCostDto to retrieve. If not provided, retrieves all InventoryCosts.</param>
     /// <returns>
     /// The task result contains a collection of InventoryCostDto DTOs. if successful, or null if no InventoryCosts match the provided identifier.
     /// </returns>
        Task<IEnumerable<InventoryCostDto>> GetInventoryCostsDetails(int? id);
        /// <summary>
        /// Inserts a new InventoryCostDto.
        /// </summary>
        /// <param name="inventoryCostDto">The DTO representing the InventoryCostDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<InventoryCostDto> InsertInventoryCostDetails(InventoryCostDto inventoryCostDto);

        /// <summary>
        /// Updates an existing InventoryCostDto.
        /// </summary>
        /// <param name="inventoryCostDto">The DTO representing the updated InventoryCostDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateInventoryCostDetails(InventoryCostDto inventoryCostDto);
        /// <summary>
        /// Deletes a InventoryCostDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the InventoryCostDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteInventoryCostDetails(int id);
    }
}