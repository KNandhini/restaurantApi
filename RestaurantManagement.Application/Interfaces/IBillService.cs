using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on Bills.
    /// </summary>
    public interface IBillService
    {/// <summary>
     /// Retrieves Bills optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the BillingDto to retrieve. If not provided, retrieves all Bills.</param>
     /// <returns>
     /// The task result contains a collection of BillingDto DTOs. if successful, or null if no Bills match the provided identifier.
     /// </returns>
        Task<IEnumerable<BillingDto>> GetBillsDetails(int? id);
        /// <summary>
        /// Inserts a new BillingDto.
        /// </summary>
        /// <param name="BillingDto">The DTO representing the BillingDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<BillingDto> InsertBillDetails(BillingDto BillingDto);

        /// <summary>
        /// Updates an existing BillingDto.
        /// </summary>
        /// <param name="BillingDto">The DTO representing the updated BillingDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateBillDetails(BillingUpdateDto BillingDto);
        /// <summary>
        /// Deletes a BillingDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the BillingDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteBillDetails(int id);
    }
}