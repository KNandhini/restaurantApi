using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Dtos
{
    public class OrderDetailDto
    {
        /// <summary>
        /// Unique ID of the order item.
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; } = 0;

        /// <summary>
        /// Associated order ID.
        /// </summary>
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; } = 0;

        /// <summary>
        /// ID of the item.
        /// </summary>
        [JsonPropertyName("itemDetails")]
        public List<OrderItemDto> ItemDetails { get; set; } = new();

        [JsonPropertyName("waiterId")]
        public int WaiterId { get; set; } = 0;
        [JsonPropertyName("orderTypeId")]
        public int OrderTypeId { get; set; } = 0;
        [JsonPropertyName("tableId")]
        public int TableId { get; set; } = 0;
        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; } = 0;
     
        /// <summary>
        /// Username of the person who created the order.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string? CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Date and time the item was created.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Username of the person who modified the order.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; } = string.Empty;

        /// <summary>
        /// Date and time the item was last modified.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Category of the table.
        /// </summary>
        [JsonPropertyName("tableCatagory")]
        public string? TableCatagory { get; set; } = string.Empty;

        /// <summary>
        /// Code of the table.
        /// </summary>
        [JsonPropertyName("tableCode")]
        public string? TableCode { get; set; } = string.Empty;

        /// <summary>
        /// Name of the customer.
        /// </summary>
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Address of the customer.
        /// </summary>
        [JsonPropertyName("customerAddress")]
        public string CustomerAddress { get; set; } = string.Empty;

        /// <summary>
        /// Phone number of the customer.
        /// </summary>
        [JsonPropertyName("customerPhoneNo")]
        public string CustomerPhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// Type of the order.
        /// </summary>
        [JsonPropertyName("orderType")]
        public string OrderType { get; set; } = string.Empty;

        /// <summary>
        /// Subtype of the order.
        /// </summary>
        [JsonPropertyName("orderSubType")]
        public string? OrderSubType { get; set; } = string.Empty;

        /// <summary>
        /// Name of the waiter.
        /// </summary>
        [JsonPropertyName("waiterName")]
        public string? WaiterName { get; set; } = string.Empty;

    

       
    }

    public class OrderItemDto
    {
        /// <summary>
        /// Unique identifier for the order item.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Associated order ID.
        /// </summary>
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        /// <summary>
        /// Associated item ID.
        /// </summary>
        [JsonPropertyName("itemId")]
        public int ItemId { get; set; }
        /// <summary>
        /// Code of the item.
        /// </summary>
        [JsonPropertyName("itemCode")]
        public string? ItemCode { get; set; } = string.Empty;

        /// <summary>
        /// Name of the item.
        /// </summary>
        [JsonPropertyName("itemName")]
        public string? ItemName { get; set; } = string.Empty;

        /// <summary>
        /// Quantity of the item.
        /// </summary>
        [JsonPropertyName("qty")]
        public int Qty { get; set; } = 1;

        /// <summary>
        /// Price of the item.
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; } = 0.0m;

        /// <summary>
        /// Indicates if the order is saved.
        /// </summary>
        [JsonPropertyName("isSave")]
        public bool IsSave { get; set; } = false;

        /// <summary>
        /// Indicates if the saved order is printed.
        /// </summary>
        [JsonPropertyName("isSavePrint")]
        public bool IsSavePrint { get; set; } = false;

        /// <summary>
        /// Indicates if it's a KOT (Kitchen Order Ticket) item.
        /// </summary>
        [JsonPropertyName("isKOT")]
        public bool IsKOT { get; set; } = false;

        /// <summary>
        /// Indicates if the KOT is printed.
        /// </summary>
        [JsonPropertyName("isKOTPrint")]
        public bool IsKOTPrint { get; set; } = false;

        /// <summary>
        /// Indicates if the order is on hold.
        /// </summary>
        [JsonPropertyName("isHold")]
        public bool IsHold { get; set; } = false;

        /// <summary>
        /// Indicates if the order is saved for e-bill.
        /// </summary>
        [JsonPropertyName("isSaveEBill")]
        public bool IsSaveEBill { get; set; } = false;

        /// <summary>
        /// Indicates if the order is completed.
        /// </summary>
        [JsonPropertyName("isOrderCompleted")]
        public bool IsOrderCompleted { get; set; } = false;

        /// <summary>
        /// Indicates if the food is Received.
        /// </summary>
        [JsonPropertyName("isFoodReceived")]
        public bool IsFoodReceived { get; set; } = false;
        

        /// <summary>
        /// Indicates if the order item is active.
        /// </summary>
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// The user who created the order item.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Date and time the order item was created.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// The user who last modified the order item.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Date and time the order item was last modified.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }
}
