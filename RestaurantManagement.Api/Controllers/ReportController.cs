using RestaurantManagement.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Data.SqlClient;
using RestaurantManagement.Application.Interfaces;

namespace RestaurantManagement.Api.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations on reportDto.
    /// </summary>
    [Route("api/reportDto")]
    [ApiController]
    public class ReportController : RestaurantManagementControllerBase
    {


        private readonly IReportService _reportService;
        /// <summary>
        /// Initializes a new instance of the <see cref="reportController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="reportService">The reportDto service instance used for CRUD operations on reportDto.</param>
        public ReportController(ILogger<ReportController> logger, IReportService reportService) : base(logger)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Retrieves all reportDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of reportDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [Route("sold-report")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GenerateSoldItemReports([FromQuery] string reportType, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate,
            [FromQuery] string category=null,
          [FromQuery] string subCategory=null,
           [FromQuery] string itemName=null,
           [FromQuery] bool? isVeg=null)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GenerateSoldItemReports));
            try
            {
                var result = await _reportService.GetReportsDetails(reportType,startDate, endDate,category,subCategory,itemName,isVeg);
                return await PrepareFileForDownload(result.ToString(), "Excel");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        private async Task<FileResult> PrepareFileForDownload(string filePath, string type)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath))
                {
                    _logger.LogWarning("File not found at path: {FilePath}", filePath);
                    return null;
                }

                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                string contentType = type.ToLower() switch
                {
                    "word" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    "excel" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "pdf" => "application/pdf",
                    _ => "application/octet-stream"
                };

                return File(fileBytes, contentType, Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to prepare file for download from path: {FilePath}", filePath);
                throw;
            }
        }



    }
}
