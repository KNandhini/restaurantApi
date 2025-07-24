using AutoMapper;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Interfaces;
using RestaurantManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on Reports.
    /// </summary>
    public class ReportService : IReportService
    {
        private readonly IReportRepository _ReportRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportService"/> class.
        /// </summary>
        /// <param name="ReportRepository">The repository for accessing ReportDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public ReportService(IReportRepository ReportRepository, IMapper mapper)
        {
            _ReportRepository = ReportRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<string> GetReportsDetails(DateTime? startDate, DateTime? endDate,
             string category,
            string subCategory,
            string itemName,
            bool? isVeg)
        {
            return await _ReportRepository.GetReportsDetails(startDate, endDate, category, subCategory, itemName, isVeg);

        }
        public async Task<(MemoryStream memory, string path)> DownloadData(string filepath)
        {
            var Path = filepath;
            var memorys = new MemoryStream();
            using (var stream = new FileStream(Path, FileMode.Open))
            {
                await stream.CopyToAsync(memorys);
            }
            return (memory: memorys, path: Path);
        }


    }
}
