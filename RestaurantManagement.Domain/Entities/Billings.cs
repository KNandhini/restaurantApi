using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class Billings
    {
        /// <summary>
        /// Unique identifier for the sale record.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0; // Default to 0

        /// <summary>
        /// Date when the sale occurred.
        /// </summary>
        [JsonPropertyName("dateOfSale")]
        public DateTime DateOfSale { get; set; } = DateTime.Now; // Default to the current date and time

        /// <summary>
        /// Day of the week when the sale occurred (e.g., Monday, Tuesday).
        /// </summary>
        [JsonPropertyName("dayOfSale")]
        public string DayOfSale { get; set; } = string.Empty; // Default to an empty string

        /// <summary>
        /// Identifier for the type of order (e.g., dine-in, takeout).
        /// </summary>
        [JsonPropertyName("orderTypeId")]
        public int OrderTypeId { get; set; } = 0; // Default to 0

        /// <summary>
        /// Identifier for the table associated with the order.
        /// </summary>
        [JsonPropertyName("tableId")]
        public int? TableId { get; set; } = null; // Default to null

        /// <summary>
        /// Identifier for the customer placing the order.
        /// </summary>
        [JsonPropertyName("customerId")]
        public int? CustomerId { get; set; } = null; // Default to null

        /// <summary>
        /// Identifier for the inventory item being sold.
        /// </summary>
        [JsonPropertyName("inventoryId")]
        public int InventoryId { get; set; } = 0; // Default to 0

        /// <summary>
        /// Identifier for the discount applied to the order.
        /// </summary>
        [JsonPropertyName("discountId")]
        public int? DiscountId { get; set; } = null; // Default to null

        /// <summary>
        /// Mode of payment used for the sale (e.g., cash, card).
        /// </summary>
        [JsonPropertyName("paymentMode")]
        public string PaymentMode { get; set; } = "Cash"; // Default to "Cash"

        /// <summary>
        /// Username of the user who created the sale record.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = "System"; // Default to "System"

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
        /// Name or description of the order type.
        /// </summary>
        [JsonPropertyName("orderType")]
        public string OrderType { get; set; } = string.Empty; // Default to an empty string

        /// <summary>
        /// Cost of the order or item.
        /// </summary>
        [JsonPropertyName("cost")]
        public decimal Cost { get; set; } = 0.0m; // Default to 0.0

        /// <summary>
        /// Name of the item being sold.
        /// </summary>
        [JsonPropertyName("itemName")]
        public string ItemName { get; set; } = string.Empty; // Default to an empty string

        /// <summary>
        /// Code identifying the item in the inventory.
        /// </summary>
        [JsonPropertyName("itemCode")]
        public string ItemCode { get; set; } = string.Empty; // Default to an empty string

        /// <summary>
        /// Code identifying the table associated with the sale.
        /// </summary>
        [JsonPropertyName("tableCode")]
        public string TableCode { get; set; } = string.Empty; // Default to an empty string

        /// <summary>
        /// Name of the table associated with the sale.
        /// </summary>
        [JsonPropertyName("tableName")]
        public string TableName { get; set; } = string.Empty; // Default to an empty string

        /// <summary>
        /// Name of the customer who placed the order.
        /// </summary>
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; } = string.Empty; // Default to an empty string

        /// <summary>
        /// Contact phone number of the customer.
        /// </summary>
        [JsonPropertyName("phoneNo")]
        public string PhoneNo { get; set; } = string.Empty; // Default to an empty string

        /// <summary>
        /// Address of the customer.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty; // Default to an empty string

        /// <summary>
        /// Discount percentage applied to the order.
        /// </summary>
        [JsonPropertyName("percentage")]
        public decimal? Percentage { get; set; } = null; // Default to null

        /// <summary>
        /// Type of discount applied (e.g., percentage-based, flat amount).
        /// </summary>
        [JsonPropertyName("discountType")]
        public string DiscountType { get; set; } = string.Empty;
    }
}
