using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on OrderTypes.
    /// </summary>
    public interface IOrderTypeService
    {/// <summary>
     /// Retrieves OrderTypes optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the OrderTypeDto to retrieve. If not provided, retrieves all OrderTypes.</param>
     /// <returns>
     /// The task result contains a collection of OrderTypeDto DTOs. if successful, or null if no OrderTypes match the provided identifier.
     /// </returns>
        Task<IEnumerable<OrderTypeDto>> GetOrderTypesDetails(int? id);
        /// <summary>
        /// Inserts a new OrderTypeDto.
        /// </summary>
        /// <param name="orderTypeDto">The DTO representing the OrderTypeDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<OrderTypeDto> InsertOrderTypeDetails(OrderTypeDto orderTypeDto);

        /// <summary>
        /// Updates an existing OrderTypeDto.
        /// </summary>
        /// <param name="orderTypeDto">The DTO representing the updated OrderTypeDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateOrderTypeDetails(OrderTypeDto orderTypeDto);
        /// <summary>
        /// Deletes a OrderTypeDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the OrderTypeDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteOrderTypeDetails(int id);
    }
}