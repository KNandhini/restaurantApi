using RestaurantManagement.Application.Dtos;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Authentication service interface.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Method to login the user into the application.
        /// </summary>
        /// <param name="username">The logging in user's username</param>
        /// <param name="password">The logging in user's password</param>
        /// <returns>The login response object.</returns>
        Task<TokenDto> LoginAsync(string username, string password);

        /// <summary>
        /// To reset the password of the user.
        /// </summary>
        /// <param name="username">The user's username </param>
        /// <param name="password">The logging in user's password</param>
        /// <returns>The reset status of the user account.</returns>
        Task<bool> ResetPasswordAsync(string username, string password);

        /// <summary>
        /// To change the password of the user.
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <param name="oldPassword">The old password used by the user</param>
        /// <param name="newPassword">The new password requested by the user</param>
        /// <returns>The change status of the user account.</returns>
        Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword);

    }
}
