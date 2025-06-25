using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Dtos
{
    public class TableDetailsDto
    {


        /// <summary>
        /// Unique identifier for the table record.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        /// <summary>
        /// Id of the table who choose the table.
        /// </summary>
        [JsonPropertyName("tableId")]
        public int TableId { get; set; } = 0; // Default to an empty string
        /// <summary>
        /// code of the table who choose the table.
        /// </summary>
        [JsonPropertyName("tableCode")]
        public string TableCode { get; set; } = string.Empty; // Default to an empty string
        /// <summary>
        /// Name of the table who choose the table.
        /// </summary>
        [JsonPropertyName("tablename")]
        public string TableName { get; set; } = string.Empty;// Default to an empty string


        /// <summary>
        /// No of seats  for the table record.
        /// </summary>
        [JsonPropertyName("noofSeats")]
        public int NoofSeats { get; set; } = 0;
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
