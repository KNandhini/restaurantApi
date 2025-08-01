using RestaurantManagement.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RestaurantManagement.Api.Controllers
{
    /// <summary>
    /// Controller for authenticating the user.
    /// </summary>
    [Route("api/authentication")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : RestaurantManagementControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="authService">The authentication service instance used for validating user.</param>
        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthService authService) : base(logger)
        {
            _authService = authService;
        }

        /// <summary>
        /// To login and generate token for the user.
        /// </summary>
        /// <param name="username">The username of logging-in user account.</param>
        /// <param name="password">The password of logging-in user account.</param>
        /// <returns>Logged in status with access token.</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(TokenDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Login([FromBody][Required] LoginUserDto user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                return BadRequestError("Email address cannot be empty.");
            }
            else if (string.IsNullOrEmpty(user.Password))
            {
                return BadRequestError("Password cannot be empty.");
            }

            try
            {
                var tokenDto = await _authService.LoginAsync(user.UserName, user.Password);
                if (tokenDto != null)
                {
                    return Ok(tokenDto);
                }
                else
                {
                    return Unauthorized(new { message = "You are not authorized to login." });
                }
            }
            catch (Exception ex)
            {
                return BadRequestError(ex);
            }
        }

        /// <summary>
        /// To reset the password of the user.
        /// </summary>
        /// <param name="username">The username of logging-in user account.</param>
        /// <param name="password">The password of logging-in user account.</param>
        /// <returns>Logged in status with access token.</returns>
        [AllowAnonymous]
        [HttpPut("reset-password")]
        [ProducesResponseType(200, Type = typeof(TokenDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> ResetPassword([FromQuery][Required] string username, [FromQuery][Required] string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequestError("Email address cannot be empty.");
            }
            else if (string.IsNullOrEmpty(password))
            {
                return BadRequestError("New password cannot be empty.");
            }

            try
            {
                var resetPasswordStatus = await _authService.ResetPasswordAsync(username, password);
                if (resetPasswordStatus)
                {
                    return SuccessMessage("Password reset is successful.");
                }
                else
                {
                    return BadRequestError("Reset password was unsuccessful.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// To change the password of the user.
        /// </summary>
        /// <param name="username">The username of logging-in user account.</param>
        /// <param name="password">The password of logging-in user account.</param>
        /// <returns>Logged in status with access token.</returns>
        [AllowAnonymous]
        [HttpPut("change-password")]
        [ProducesResponseType(200, Type = typeof(TokenDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> ChangePassword([FromQuery][Required] string username, [FromQuery][Required] string oldPassword, [FromQuery][Required] string newPassword)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequestError("Username cannot be empty.");
            }
            else if (string.IsNullOrEmpty(oldPassword))
            {
                return BadRequestError("Exisiting password cannot be empty.");
            }
            else if (string.IsNullOrEmpty(newPassword))
            {
                return BadRequestError("New password cannot be empty.");
            }
          
            try
            {
                var resetPasswordStatus = await _authService.ChangePasswordAsync(username, oldPassword,newPassword);
                if (resetPasswordStatus)
                {
                    return SuccessMessage("Password change is successful.");
                }
                else
                {
                    return BadRequestError("Change password was unsuccessful.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        
    }
}
