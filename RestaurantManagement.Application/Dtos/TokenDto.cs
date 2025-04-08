namespace RestaurantManagement.Application.Dtos
{
    /// <summary>
    /// The token response Dto class.
    /// </summary>
    public class TokenDto
    {
        /// <summary>
        /// The token to be used for accessing the resources.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// The token expiry time.
        /// </summary>
        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// The Role Id of login user.
        /// </summary>
        public Int32 RoleId { get; set; } = 0;
        /// <summary>
        /// The Name of the login user.
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// The Role Name of the login user.
        /// </summary>
        public string RoleName { get; set; } = string.Empty;
        /// <summary>
        /// The User Id of login user.
        /// </summary>
        public int UserId { get; set; } = 0;
        /// <summary>
        /// Gets or sets the Photo of the user.
        /// </summary>
        public byte[] Photo { get; set; }

    }
    
}
