using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on InventoryCosts.
    /// </summary>
    public interface IInventoryCostRepository
    { /// <summary>
      /// Retrieves InventoryCosts optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the InventoryCosts to retrieve. If not provided, retrieves all InventoryCostss.</param>
      /// <returns>
      /// The task result contains a collection of InventoryCosts if successful, or null if no InventoryCostss match the provided identifier.
      /// </returns>
        Task<IEnumerable<InventoryCost>> GetInventoryCostsDetails(int? id);
        /// <summary>
        /// Inserts a new InventoryCosts.
        /// </summary>
        /// <param name="InventoryCosts">The InventoryCosts to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<InventoryCost> InsertInventoryCostDetails(InventoryCost InventoryCosts);
        /// <summary>
        /// Updates an existing InventoryCosts.
        /// </summary>
        /// <param name="InventoryCosts">The InventoryCosts to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateInventoryCostDetails(InventoryCost InventoryCosts);
        /// <summary>
        /// Deletes a InventoryCosts by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the InventoryCosts to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteInventoryCostDetails(int id);
    }
}
