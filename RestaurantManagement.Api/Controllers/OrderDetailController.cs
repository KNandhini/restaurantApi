using RestaurantManagement.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Data.SqlClient;
using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantManagement.Api.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations on orderDetailDto.
    /// </summary>
    [Route("api/orderDetail")]
    [ApiController]
    [Authorize]
    public class OrderDetailController : RestaurantManagementControllerBase
    {


        private readonly IOrderDetailService _orderDetailService;
        /// <summary>
        /// Initializes a new instance of the <see cref="orderDetailController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="orderDetailService">The orderDetailDto service instance used for CRUD operations on orderDetailDto.</param>
        public OrderDetailController(ILogger<OrderDetailController> logger, IOrderDetailService orderDetailService) : base(logger)
        {
            _orderDetailService = orderDetailService;
        }

        /// <summary>
        /// Retrieves all orderDetailDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of orderDetailDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDetailDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllOrderDetails));
            try
            {
                var result = await _orderDetailService.GetOrderDetailsDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a orderDetailDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the orderDetailDto.</param>
        /// <returns>
        /// The response with the orderDetailDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderDetailDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetOrderDetailById), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var orderDetailDto = await _orderDetailService.GetOrderDetailsDetails(id);

                if (orderDetailDto == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Order details not found.");

                return orderDetailDto.Id != 0
                    ? Ok(orderDetailDto)
                    : StatusCode(StatusCodes.Status404NotFound, "Order ID not valid.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        /// <summary>
        /// Inserts a new orderDetailDto.
        /// </summary>
        /// <param name="orderDetailDto">The DTO representing the orderDetailDto to insert.</param>
        /// <returns>
        /// The response with the created orderDetailDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertOrderDetail([FromBody] OrderDetailDto orderDetailDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertOrderDetail));
            try
            {
                // Insert the orderDetailDto and retrieve the data
                var OrderDetail = await _orderDetailService.InsertOrderDetails(orderDetailDto);


                return CreatedAtAction(nameof(GetAllOrderDetails), new { id = orderDetailDto.Id }, OrderDetail);
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
        /// Updates an existing orderDetailDto.
        /// </summary>
        /// <param name="orderDetailDto">The DTO representing the updated orderDetailDto.</param>
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
        public async Task<IActionResult> UpdateFoodReceivedByItem([FromBody] List<UpdateFoodReceivedRequestDto> orderDetailDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateFoodReceivedByItem));
            //var OrderDetails = await _orderDetailService.GetOrderDetailsDetails((int?)orderDetailDto.OrderId);
            //if (OrderDetails == null)
            //{
            //    return NotFound();
            //}

            try
            {
                await _orderDetailService.UpdateOrderDetailDetails(orderDetailDto);
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
        /// Deletes a orderDetailDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the orderDetailDto to delete.</param>
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
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteOrderDetail), id);
            var orderDetailDto = await _orderDetailService.GetOrderDetailsDetails(id);
            if (orderDetailDto == null)
            {
                return NotFound();
            }

            try
            {
                await _orderDetailService.DeleteOrderDetailDetails(id);
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
