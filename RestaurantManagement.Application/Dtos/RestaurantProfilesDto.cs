using System;
using System.Text.Json.Serialization;

namespace RestaurantManagement.Domain.Entities
{
    /// <summary>
    /// Data Transfer Object for restaurant profile information.
    /// </summary>
    public class RestaurantProfilesDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("restaurantName")]
        public string RestaurantName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; } = string.Empty;

        [JsonPropertyName("cgst")]
        public decimal CGST { get; set; }

        [JsonPropertyName("sgst")]
        public decimal SGST { get; set; }

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }
}
