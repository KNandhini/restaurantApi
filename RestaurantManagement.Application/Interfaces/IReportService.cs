using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on Reports.
    /// </summary>
    public interface IReportService
    {/// <summary>
     /// Retrieves Reports optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the ReportDto to retrieve. If not provided, retrieves all Reports.</param>
     /// <returns>
     /// The task result contains a collection of ReportDto DTOs. if successful, or null if no Reports match the provided identifier.
     /// </returns>
        Task<object> GetReportsDetails(string reportType,DateTime? startDate, DateTime? endDate,
             string category,
            string subCategory,
            string itemName,
            bool? isVeg);
        Task<(MemoryStream memory, string path)> DownloadData(string filepath);


    }
}