using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Entities
{
    public class OrderDetail
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer ID associated with the order.
        /// </summary>
        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the table ID where the order was placed.
        /// </summary>
        [JsonPropertyName("tableId")]
        public int TableId { get; set; }

        /// <summary>
        /// Gets or sets the order type ID (e.g., dine-in, takeout).
        /// </summary>
        [JsonPropertyName("orderTypeId")]
        public int OrderTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the order is closed.
        /// </summary>
        [JsonPropertyName("isOrderClosed")]
        public bool IsOrderClosed { get; set; }

        /// <summary>
        /// Gets or sets the waiter ID who handled the order.
        /// </summary>
        [JsonPropertyName("waiterId")]
        public int WaiterId { get; set; }

        /// <summary>
        /// Gets or sets the user who created the order.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the order was created.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the user who last modified the order.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the order was last modified.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the category of the table.
        /// </summary>
        [JsonPropertyName("tableCategory")]
        public string TableCategory { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the code of the table.
        /// </summary>
        [JsonPropertyName("tableCode")]
        public string TableCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the customer's name.
        /// </summary>
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the customer's address.
        /// </summary>
        [JsonPropertyName("customerAddress")]
        public string CustomerAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        [JsonPropertyName("customerPhoneNo")]
        public string CustomerPhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the order type (e.g., dine-in, delivery).
        /// </summary>
        [JsonPropertyName("orderType")]
        public string OrderType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the order sub-type (e.g., online, phone).
        /// </summary>
        [JsonPropertyName("orderSubType")]
        public string OrderSubType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the waiter who handled the order.
        /// </summary>
        [JsonPropertyName("waiterName")]
        public string WaiterName { get; set; } = string.Empty;
    }