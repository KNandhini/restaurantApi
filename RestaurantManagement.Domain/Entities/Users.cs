using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class Users
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the role ID associated with the user.
        /// </summary>
        [JsonPropertyName("roleId")]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        [JsonPropertyName("phoneNo")]
        public string PhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the address of the user.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the locality of the user.
        /// </summary>
        [JsonPropertyName("locality")]
        public string? Locality { get; set; } = null;

        /// <summary>
        /// Gets or sets additional information about the user.
        /// </summary>
        [JsonPropertyName("info")]
        public string? Info { get; set; } = null;

        /// <summary>
        /// Gets or sets the username for the user.
        /// </summary>
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for the user.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user who created the record.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time the record was created.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the user who last modified the record.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; } = null;

        /// <summary>
        /// Gets or sets the date and time the record was last modified.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the role name associated with the user.
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;
    }
}
