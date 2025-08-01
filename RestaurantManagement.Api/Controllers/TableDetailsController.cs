using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using System.Data.SqlClient;
using System.Net;

namespace RestaurantManagement.Api.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations on tableDetailsDto.
    /// </summary>
    [Route("api/tableDetailsDto")]
    [ApiController]
    [Authorize]
    public class TableDetailsController : RestaurantManagementControllerBase
    {
        private readonly ITableDetailsService _TableDetailsService;
    /// <summary>
    /// Initializes a new instance of the <see cref="TableDetailsController"/> class.
    /// </summary>
    /// <param name="logger">The logger instance used for logging.</param>
    /// <param name="TableDetailsService">The TableDetailsDto service instance used for CRUD operations on TableDetailsDto.</param>
    public TableDetailsController(ILogger<TableDetailsController> logger, ITableDetailsService TableDetailsService) : base(logger)
    {
        _TableDetailsService = TableDetailsService;
    }

    /// <summary>
    /// Retrieves all TableDetailsDto.
    /// </summary>
    /// <returns>
    /// The response with a collection of TableDetailsDto DTOs if successful, or a problem 
    /// details object indicating the error if the operation fails.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<TableDetailsDto>))]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
    public async Task<IActionResult> GetAllTableDetails()
    {
        _logger.LogInformation("{MethodName} method is called", nameof(GetAllTableDetails));
        try
        {
            var result = await _TableDetailsService.GetTableDetails(null);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

        /// <summary>
        /// Retrieves all mapping TableDetailsDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of TableDetailsDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("tableMapping")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TableMappingDetailsDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllMappingTableDetails()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllMappingTableDetails));
            try
            {
                var result = await _TableDetailsService.GetMappingTableDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieves a TableDetailsDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the TableDetailsDto.</param>
        /// <returns>
        /// The response with the TableDetailsDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(TableDetailsDto))]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

    public async Task<IActionResult> GetTableDetailsById(int id)
    {
        _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetTableDetailsById), id);
        if (id < 1)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        try
        {
            var TableDetailsDto = await _TableDetailsService.GetTableDetails(id);
            return TableDetailsDto.Count() == 1 ? Ok(TableDetailsDto) : StatusCode(StatusCodes.Status404NotFound);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }
    /// <summary>
    /// Inserts a new TableDetailsDto.
    /// </summary>
    /// <param name="TableDetailsDto">The DTO representing the TableDetailsDto to insert.</param>
    /// <returns>
    /// The response with the created TableDetailsDto DTO if successful, or a problem details 
    /// object indicating the error if the operation fails.
    /// </returns>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
    public async Task<IActionResult> InsertTableDetails([FromBody] TableDetailsDto TableDetailsDto)
    {
        _logger.LogInformation("{MethodName} method is called", nameof(InsertTableDetails));
        try
        {
            // Insert the TableDetailsDto and retrieve the data
            var TableDetailsDetail = await _TableDetailsService.InsertTableDetails(TableDetailsDto);


            return CreatedAtAction(nameof(GetAllTableDetails), new { id = TableDetailsDto.Id }, TableDetailsDetail);
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
    /// Updates an existing TableDetailsDto.
    /// </summary>
    /// <param name="TableDetailsDto">The DTO representing the updated TableDetailsDto.</param>
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
    public async Task<IActionResult> UpdateTableDetails([FromBody] TableDetailsDto TableDetailsDto)
    {
        _logger.LogInformation("{MethodName} method is called", nameof(UpdateTableDetails));
        var TableDetails = await _TableDetailsService.GetTableDetails((int?)TableDetailsDto.Id);
        if (TableDetails == null)
        {
            return NotFound();
        }

        try
        {
            await _TableDetailsService.UpdateTableDetails(TableDetailsDto);
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
    /// Deletes a TableDetailsDto by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the TableDetailsDto to delete.</param>
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
    public async Task<IActionResult> DeleteTableDetails(int id)
    {
        _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteTableDetails), id);
        var TableDetailsDto = await _TableDetailsService.GetTableDetails(id);
        if (TableDetailsDto == null)
        {
            return NotFound();
        }

        try
        {
            await _TableDetailsService.DeleteTableDetails(id);
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
