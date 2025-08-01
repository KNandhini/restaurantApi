using RestaurantManagement.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Data.SqlClient;
using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantManagement.Api.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations on inventoryDto.
    /// </summary>
    [Route("api/inventoryCostDto")]
    [ApiController]
    [Authorize]
    public class InventoryCostController : RestaurantManagementControllerBase
    {


        private readonly IInventoryCostService _inventoryCostService;
        /// <summary>
        /// Initializes a new instance of the <see cref="inventoryController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="inventoryService">The inventoryDto service instance used for CRUD operations on inventoryDto.</param>
        public InventoryCostController(ILogger<InventoryCostController> logger, IInventoryCostService inventoryCostService) : base(logger)
        {
            _inventoryCostService = inventoryCostService;
        }

        /// <summary>
        /// Retrieves all inventoryDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of inventoryDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InventoryCostDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllInventoryCosts()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllInventoryCosts));
            try
            {
                var result = await _inventoryCostService.GetInventoryCostsDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a inventoryDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the inventoryDto.</param>
        /// <returns>
        /// The response with the inventoryDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(InventoryCostDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetInventoryCostById(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetInventoryCostById), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var inventoryDto = await _inventoryCostService.GetInventoryCostsDetails(id);
                return inventoryDto.Count() == 1 ? Ok(inventoryDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new inventoryDto.
        /// </summary>
        /// <param name="inventoryDto">The DTO representing the inventoryDto to insert.</param>
        /// <returns>
        /// The response with the created inventoryDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertInventoryCost([FromBody] InventoryCostDto inventoryDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertInventoryCost));
            try
            {
                // Insert the inventoryDto and retrieve the data
                var InventoryCostDetail = await _inventoryCostService.InsertInventoryCostDetails(inventoryDto);


                return CreatedAtAction(nameof(GetAllInventoryCosts), new { id = inventoryDto.Id }, InventoryCostDetail);
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
        /// Updates an existing inventoryDto.
        /// </summary>
        /// <param name="inventoryDto">The DTO representing the updated inventoryDto.</param>
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
        public async Task<IActionResult> UpdateInventoryCost([FromBody] InventoryCostDto inventoryDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateInventoryCost));
            var inventoryDetails = await _inventoryCostService.GetInventoryCostsDetails((int?)inventoryDto.Id);
            if (inventoryDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _inventoryCostService.UpdateInventoryCostDetails(inventoryDto);
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
        /// Deletes a inventoryDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the inventoryDto to delete.</param>
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
        public async Task<IActionResult> DeleteInventoryCost(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteInventoryCost), id);
            var inventoryDto = await _inventoryCostService.GetInventoryCostsDetails(id);
            if (inventoryDto == null)
            {
                return NotFound();
            }

            try
            {
                await _inventoryCostService.DeleteInventoryCostDetails(id);
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
