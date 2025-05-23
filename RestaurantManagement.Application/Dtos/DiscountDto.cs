﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Dtos
{
    public class DiscountDto
    {
        /// <summary>
        /// Unique identifier for the sale record.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0; // Default to 0

        /// <summary>
        /// Name or description of the order type.
        /// </summary>
        [JsonPropertyName("discountType")]
        public string DiscountType { get; set; } = string.Empty; 

        /// <summary>
        /// Discount percentage applied to the order.
        /// </summary>
        [JsonPropertyName("percentage")]
        public string Percentage { get; set; } = string.Empty; // Default to null

        /// <summary>
        /// Valid up to  applied to the order.
        /// </summary>
        [JsonPropertyName("validUpto")]
        public string ValidUpto { get; set; } = null; // Default to null

        /// <summary>
        /// Gets or sets the user who created the record.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Date and time when the sale record was created.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Default to current date and time

        /// <summary>
        /// Username of the user who last modified the sale record.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string ModifiedBy { get; set; } = "System"; // Default to "System"

        /// <summary>
        /// Date and time when the sale record was last modified.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; } = null; // Default to null

        /// <summary>
        /// Unique discount code.
        /// </summary>
        [JsonPropertyName("discountCode")]
        public string DiscountCode { get; set; } = string.Empty; // Default to an empty string
    }
}
