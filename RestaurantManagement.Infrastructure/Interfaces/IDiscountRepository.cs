using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on Discounts.
    /// </summary>
    public interface IDiscountRepository
    { /// <summary>
      /// Retrieves Discounts optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the Discount to retrieve. If not provided, retrieves all Discounts.</param>
      /// <returns>
      /// The task result contains a collection of Discounts if successful, or null if no Discounts match the provided identifier.
      /// </returns>
        Task<IEnumerable<Discounts>> GetDiscountsDetails(int? id);
        /// <summary>
        /// Inserts a new Discount.
        /// </summary>
        /// <param name="Discount">The Discount to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<Discounts> InsertDiscountDetails(Discounts Discount);
        /// <summary>
        /// Updates an existing Discount.
        /// </summary>
        /// <param name="Discount">The Discount to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateDiscountDetails(Discounts Discount);
        /// <summary>
        /// Deletes a Discount by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the Discount to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteDiscountDetails(int id);
    }
}
