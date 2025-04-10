using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Dtos
{
    public class OrderTypeDto
    { /// <summary>
      /// Unique identifier for the order type.
      /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Main type of the order.
        /// </summary>
        [JsonPropertyName("orderType")]
        public string OrderType { get; set; }

        /// <summary>
        /// Sub type of the order, if any.
        /// </summary>
        [JsonPropertyName("subType")]
        public string? SubType { get; set; }

        /// <summary>
        /// User who created the record.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date and time the record was created.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// User who last modified the record.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Date and time the record was last modified.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }
}
