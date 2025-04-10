using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on OrderTypes.
    /// </summary>
    public interface IOrderTypeRepository
    { /// <summary>
      /// Retrieves OrderTypes optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the OrderTypes to retrieve. If not provided, retrieves all OrderTypess.</param>
      /// <returns>
      /// The task result contains a collection of OrderTypes if successful, or null if no OrderTypess match the provided identifier.
      /// </returns>
        Task<IEnumerable<OrderTypes>> GetOrderTypesDetails(int? id);
        /// <summary>
        /// Inserts a new OrderTypes.
        /// </summary>
        /// <param name="orderTypes">The OrderTypes to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<OrderTypes> InsertOrderTypeDetails(OrderTypes orderTypes);
        /// <summary>
        /// Updates an existing OrderTypes.
        /// </summary>
        /// <param name="orderTypes">The OrderTypes to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateOrderTypeDetails(OrderTypes orderTypes);
        /// <summary>
        /// Deletes a OrderTypes by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the OrderTypes to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteOrderTypeDetails(int id);
        /// <summary>
        /// reset a labour password.
        /// </summary>
        /// <param name="orderTypename">The orderTypename of the labour to update.</param>
        /// <param name="password">The password of the labour to update.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task ResetPasswordAsync(int id, string orderTypename, string newPassword, string modifiedBy);
    }
}
