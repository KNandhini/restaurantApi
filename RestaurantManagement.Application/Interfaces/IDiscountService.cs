using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on Discounts.
    /// </summary>
    public interface IDiscountService
    {/// <summary>
     /// Retrieves Discounts optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the DiscountDto to retrieve. If not provided, retrieves all Discounts.</param>
     /// <returns>
     /// The task result contains a collection of DiscountDto DTOs. if successful, or null if no Discounts match the provided identifier.
     /// </returns>
        Task<IEnumerable<DiscountDto>> GetDiscountsDetails(int? id);
        /// <summary>
        /// Inserts a new DiscountDto.
        /// </summary>
        /// <param name="discountDto">The DTO representing the DiscountDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<DiscountDto> InsertDiscountDetails(DiscountDto discountDto);

        /// <summary>
        /// Updates an existing DiscountDto.
        /// </summary>
        /// <param name="discountDto">The DTO representing the updated DiscountDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateDiscountDetails(DiscountDto discountDto);
        /// <summary>
        /// Deletes a DiscountDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the DiscountDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteDiscountDetails(int id);
    }
}