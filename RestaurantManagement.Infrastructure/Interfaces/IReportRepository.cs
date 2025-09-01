using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on Reports.
    /// </summary>
    public interface IReportRepository
    { /// <summary>
      /// Retrieves Reports optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the Reports to retrieve. If not provided, retrieves all Reportss.</param>
      /// <returns>
      /// The task result contains a collection of Reports if successful, or null if no Reportss match the provided identifier.
      /// </returns>
        Task<object> GetReportsDetails(string reportType,DateTime? startDate, DateTime? endDate,
             string category,
            string subCategory,
            string itemName,
            bool? isVeg);
        
    }
}
