﻿using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on Customers.
    /// </summary>
    public interface ICustomerRepository
    { /// <summary>
      /// Retrieves Customers optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the Customers to retrieve. If not provided, retrieves all Customerss.</param>
      /// <returns>
      /// The task result contains a collection of Customers if successful, or null if no Customerss match the provided identifier.
      /// </returns>
        Task<IEnumerable<Customers>> GetCustomersDetails(int? id);
        /// <summary>
        /// Inserts a new Customers.
        /// </summary>
        /// <param name="Customers">The Customers to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<Customers> InsertCustomerDetails(Customers Customers);
        /// <summary>
        /// Updates an existing Customers.
        /// </summary>
        /// <param name="Customers">The Customers to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateCustomerDetails(Customers Customers);
        /// <summary>
        /// Deletes a Customers by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the Customers to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteCustomerDetails(int id);

        Task<IEnumerable<Customers>> GetCustomerByPhoneNumber(string mobileNo);
    }
}
