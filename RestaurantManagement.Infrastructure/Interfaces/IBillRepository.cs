using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on Bills.
    /// </summary>
    public interface IBillRepository
    { /// <summary>
      /// Retrieves Bills optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the Bill to retrieve. If not provided, retrieves all Bills.</param>
      /// <returns>
      /// The task result contains a collection of Bills if successful, or null if no Bills match the provided identifier.
      /// </returns>
        Task<IEnumerable<Billings>> GetBillsDetails(int? id);
        /// <summary>
        /// Inserts a new Bill.
        /// </summary>
        /// <param name="Bill">The Bill to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<Billings> InsertBillDetails(Billings Bill);
        /// <summary>
        /// Updates an existing Bill.
        /// </summary>
        /// <param name="Bill">The Bill to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateBillDetails(BillingUpdate Bill);
        /// <summary>
        /// Deletes a Bill by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the Bill to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteBillDetails(int id);
    }
}
