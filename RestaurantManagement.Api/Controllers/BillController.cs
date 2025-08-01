using RestaurantManagement.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Data.SqlClient;
using RestaurantManagement.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantManagement.Api.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations on billingDto.
    /// </summary>
    [Route("api/billingDto")]
    [ApiController]
    [Authorize]
    public class BillController : RestaurantManagementControllerBase
    {


        private readonly IBillService _billService;
        /// <summary>
        /// Initializes a new instance of the <see cref="billController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="billService">The billingDto service instance used for CRUD operations on billingDto.</param>
        public BillController(ILogger<BillController> logger, IBillService billService) : base(logger)
        {
            _billService = billService;
        }

        /// <summary>
        /// Retrieves all billingDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of billingDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BillingDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllBills()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllBills));
            try
            {
                var result = await _billService.GetBillsDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a billingDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the billingDto.</param>
        /// <returns>
        /// The response with the billingDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(BillingDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetBillById(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetBillById), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var billingDto = await _billService.GetBillsDetails(id);
                return billingDto.Count() == 1 ? Ok(billingDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new billingDto.
        /// </summary>
        /// <param name="billingDto">The DTO representing the billingDto to insert.</param>
        /// <returns>
        /// The response with the created billingDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertBilling([FromBody] BillingDto billingDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertBilling));
            try
            {
                // Insert the billingDto and retrieve the data
                var BillingDetail = await _billService.InsertBillDetails(billingDto);


                return CreatedAtAction(nameof(GetAllBills), new { id = billingDto.Id }, BillingDetail);
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
        /// Updates an existing billingDto.
        /// </summary>
        /// <param name="billingDto">The DTO representing the updated billingDto.</param>
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
        public async Task<IActionResult> UpdateBill([FromBody] BillingUpdateDto billingDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateBill));
            //var billingDetails = await _billService.GetBillsDetails((int?)billingDto.Id);
            //if (billingDetails == null)
            //{
            //    return NotFound();
            //}

            try
            {
                await _billService.UpdateBillDetails(billingDto);
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
        /// Deletes a billingDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the billingDto to delete.</param>
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
        public async Task<IActionResult> DeleteBill(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteBill), id);
            var billingDto = await _billService.GetBillsDetails(id);
            if (billingDto == null)
            {
                return NotFound();
            }

            try
            {
                await _billService.DeleteBillDetails(id);
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
