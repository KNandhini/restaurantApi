using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using System.Data.SqlClient;
using System.Net;

namespace RestaurantManagement.Api.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations on tableMaterDto.
    /// </summary>
    [Route("api/tableMaterDto")]
    [ApiController]
    [Authorize]
    public class TableMasterController : RestaurantManagementControllerBase
    {
        private readonly ITableMasterService _TableMasterService;
        /// <summary>
        /// Initializes a new instance of the <see cref="TableMasterController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="TableMasterService">The TableMasterDto service instance used for CRUD operations on TableMasterDto.</param>
        public TableMasterController(ILogger<TableMasterController> logger, ITableMasterService TableMasterService) : base(logger)
        {
            _TableMasterService = TableMasterService;
        }

        /// <summary>
        /// Retrieves all TableMasterDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of TableMasterDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TableMasterDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllTableMasters()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllTableMasters));
            try
            {
                var result = await _TableMasterService.GetTableMastersDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a TableMasterDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the TableMasterDto.</param>
        /// <returns>
        /// The response with the TableMasterDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TableMasterDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetTableMasterById(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetTableMasterById), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var TableMasterDto = await _TableMasterService.GetTableMastersDetails(id);
                return TableMasterDto.Count() == 1 ? Ok(TableMasterDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new TableMasterDto.
        /// </summary>
        /// <param name="TableMasterDto">The DTO representing the TableMasterDto to insert.</param>
        /// <returns>
        /// The response with the created TableMasterDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertTableMaster([FromBody] TableMasterDto TableMasterDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertTableMaster));
            try
            {
                // Insert the TableMasterDto and retrieve the data
                var TableMasterDetail = await _TableMasterService.InsertTableMasterDetails(TableMasterDto);


                return CreatedAtAction(nameof(GetAllTableMasters), new { id = TableMasterDto.Id }, TableMasterDetail);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Database Error",
                    Detail = "An error occurred while processing your request. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
        }

        /// <summary>
        /// Updates an existing TableMasterDto.
        /// </summary>
        /// <param name="TableMasterDto">The DTO representing the updated TableMasterDto.</param>
        /// <returns>
        /// The response with no content if the update is successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> UpdateTableMaster([FromBody] TableMasterDto TableMasterDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateTableMaster));
            var TableMasterDetails = await _TableMasterService.GetTableMastersDetails((int?)TableMasterDto.Id);
            if (TableMasterDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _TableMasterService.UpdateTableMasterDetails(TableMasterDto);
                return NoContent();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Database Error",
                    Detail = "An error occurred while processing your request. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
        }

        /// <summary>
        /// Deletes a TableMasterDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the TableMasterDto to delete.</param>
        /// <returns>
        /// The response with no content if the deletion is successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> DeleteTableMaster(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteTableMaster), id);
            var TableMasterDto = await _TableMasterService.GetTableMastersDetails(id);
            if (TableMasterDto == null)
            {
                return NotFound();
            }

            try
            {
                await _TableMasterService.DeleteTableMasterDetails(id);
                return NoContent();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Database Error",
                    Detail = "An error occurred while processing your request. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
        }
    }
}
