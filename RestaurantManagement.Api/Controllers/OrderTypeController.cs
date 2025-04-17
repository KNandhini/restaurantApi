using RestaurantManagement.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Data.SqlClient;
using RestaurantManagement.Application.Interfaces;

namespace RestaurantManagement.Api.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations on orderTypeDto.
    /// </summary>
    [Route("api/orderType")]
    [ApiController]
    public class OrderTypeController : RestaurantManagementControllerBase
    {


        private readonly IOrderTypeService _orderTypeService;
        /// <summary>
        /// Initializes a new instance of the <see cref="orderTypeController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="orderTypeService">The orderTypeDto service instance used for CRUD operations on orderTypeDto.</param>
        public OrderTypeController(ILogger<OrderTypeController> logger, IOrderTypeService orderTypeService) : base(logger)
        {
            _orderTypeService = orderTypeService;
        }

        /// <summary>
        /// Retrieves all orderTypeDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of orderTypeDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderTypeDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllOrderTypes()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllOrderTypes));
            try
            {
                var result = await _orderTypeService.GetOrderTypesDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a orderTypeDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the orderTypeDto.</param>
        /// <returns>
        /// The response with the orderTypeDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderTypeDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetOrderTypeById(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetOrderTypeById), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var orderTypeDto = await _orderTypeService.GetOrderTypesDetails(id);
                return orderTypeDto.Count() == 1 ? Ok(orderTypeDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new orderTypeDto.
        /// </summary>
        /// <param name="orderTypeDto">The DTO representing the orderTypeDto to insert.</param>
        /// <returns>
        /// The response with the created orderTypeDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertOrderType([FromBody] OrderTypeDto orderTypeDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertOrderType));
            try
            {
                // Insert the orderTypeDto and retrieve the data
                var OrderTypeDetail = await _orderTypeService.InsertOrderTypeDetails(orderTypeDto);


                return CreatedAtAction(nameof(GetAllOrderTypes), new { id = orderTypeDto.Id }, OrderTypeDetail);
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
        /// Updates an existing orderTypeDto.
        /// </summary>
        /// <param name="orderTypeDto">The DTO representing the updated orderTypeDto.</param>
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
        public async Task<IActionResult> UpdateOrderType([FromBody] OrderTypeDto orderTypeDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateOrderType));
            var orderTypeDetails = await _orderTypeService.GetOrderTypesDetails((int?)orderTypeDto.Id);
            if (orderTypeDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _orderTypeService.UpdateOrderTypeDetails(orderTypeDto);
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
        /// Deletes a orderTypeDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the orderTypeDto to delete.</param>
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
        public async Task<IActionResult> DeleteOrderType(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteOrderType), id);
            var orderTypeDto = await _orderTypeService.GetOrderTypesDetails(id);
            if (orderTypeDto == null)
            {
                return NotFound();
            }

            try
            {
                await _orderTypeService.DeleteOrderTypeDetails(id);
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
