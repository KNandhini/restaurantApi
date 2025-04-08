using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Dtos
{
    public class CustomerDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the customer.
        /// </summary>
        [JsonPropertyName("phoneNo")]
        public string PhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the address of the customer.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the locality of the customer.
        /// </summary>
        [JsonPropertyName("locality")]
        public string? Locality { get; set; } = null;

        /// <summary>
        /// Gets or sets additional information about the customer.
        /// </summary>
        [JsonPropertyName("info")]
        public string? Info { get; set; } = null;

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
    }
}
