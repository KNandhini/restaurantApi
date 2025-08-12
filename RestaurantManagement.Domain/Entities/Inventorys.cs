using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class Inventorys
    {
        /// <summary>
        /// Gets or sets the unique identifier for the menu item.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique code for the menu item.
        /// </summary>
        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category of the menu item.
        /// </summary>
        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the subcategory of the menu item.
        /// </summary>
        [JsonPropertyName("subCategory")]
        public string SubCategory { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the menu item.
        /// </summary>
        [JsonPropertyName("itemName")]
        public string ItemName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the item is vegetarian.
        /// </summary>
        [JsonPropertyName("isVeg")]
        public bool IsVeg { get; set; } = true;
       
        /// <summary>
        /// Gets or sets the description of the menu item.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("uom")]
        public string Uom { get; set; } = string.Empty;
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

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("uom")]
        public string Uom { get; set; } = string.Empty;
    }
}
