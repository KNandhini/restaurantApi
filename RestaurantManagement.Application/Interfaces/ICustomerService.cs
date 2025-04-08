using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on Customers.
    /// </summary>
    public interface ICustomerService
    {/// <summary>
     /// Retrieves Customers optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the CustomerDto to retrieve. If not provided, retrieves all Customers.</param>
     /// <returns>
     /// The task result contains a collection of CustomerDto DTOs. if successful, or null if no Customers match the provided identifier.
     /// </returns>
        Task<IEnumerable<CustomerDto>> GetCustomersDetails(int? id);
        /// <summary>
        /// Inserts a new CustomerDto.
        /// </summary>
        /// <param name="CustomerDto">The DTO representing the CustomerDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<CustomerDto> InsertCustomerDetails(CustomerDto CustomerDto);

        /// <summary>
        /// Updates an existing CustomerDto.
        /// </summary>
        /// <param name="CustomerDto">The DTO representing the updated CustomerDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateCustomerDetails(CustomerDto CustomerDto);
        /// <summary>
        /// Deletes a CustomerDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the CustomerDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteCustomerDetails(int id);
    }
}