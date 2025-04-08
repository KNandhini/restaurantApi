using System.Text.Json.Serialization;

namespace RestaurantManagement.Application.Dtos
{
    /// <summary>
    /// The logging-in user details.
    /// </summary>
    public class LoginUserDto
    {
        /// <summary>
        /// The username of the logging-in user.
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// The password of the logging-in user.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
