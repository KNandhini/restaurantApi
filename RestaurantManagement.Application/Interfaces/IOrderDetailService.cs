using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on OrderDetails.
    /// </summary>
    public interface IOrderDetailService
    {/// <summary>
     /// Retrieves OrderDetails optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the OrderDetailDto to retrieve. If not provided, retrieves all OrderDetails.</param>
     /// <returns>
     /// The task result contains a collection of OrderDetailDto DTOs. if successful, or null if no OrderDetails match the provided identifier.
     /// </returns>
        Task<OrderDetailDto> GetOrderDetailsDetails(int? id);
        /// <summary>
        /// Inserts a new OrderDetailDto.
        /// </summary>
        /// <param name="orderDetailDto">The DTO representing the OrderDetailDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<OrderDetailDto> InsertOrderDetails(OrderDetailDto orderDetailDto);

        /// <summary>
        /// Updates an existing OrderDetailDto.
        /// </summary>
        /// <param name="orderDetailDto">The DTO representing the updated OrderDetailDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateOrderDetailDetails(List<UpdateFoodReceivedRequestDto> orderDetailDto);
        /// <summary>
        /// Deletes a OrderDetailDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the OrderDetailDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteOrderDetailDetails(int id);
       
    }
}