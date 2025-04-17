using System;
using System.Collections.Generic;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on OrderDetails.
    /// </summary>
    public interface IOrderDetailRepository
    { /// <summary>
      /// Retrieves OrderDetails optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the OrderDetails to retrieve. If not provided, retrieves all OrderDetailss.</param>
      /// <returns>
      /// The task result contains a collection of OrderDetails if successful, or null if no OrderDetailss match the provided identifier.
      /// </returns>
        Task<OrderDetail> GetOrderDetailsDetails(int? id);
        /// <summary>
        /// Inserts a new OrderDetails.
        /// </summary>
        /// <param name="orderDetails">The OrderDetails to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<OrderDetail> InsertOrderDetails(OrderDetail orderDetails);
        /// <summary>
        /// Updates an existing OrderDetails.
        /// </summary>
        /// <param name="orderDetails">The OrderDetails to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateOrderDetailDetails(UpdateFoodReceivedRequest orderDetails);
        /// <summary>
        /// Deletes a OrderDetails by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the OrderDetails to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteOrderDetailDetails(int id);
    }
}
