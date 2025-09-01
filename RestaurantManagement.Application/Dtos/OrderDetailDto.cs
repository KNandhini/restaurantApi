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

        [JsonPropertyName("seatId")]
        public string SeatId { get; set; } = string.Empty;

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
        /// Gets or sets the locality of the customer.
        /// </summary>
        [JsonPropertyName("customerLocality")]
        public string? CustomerLocality { get; set; } = null;

        /// <summary>
        /// Gets or sets additional information about the customer.
        /// </summary>
        [JsonPropertyName("customerInfo")]
        public string? CustomerInfo { get; set; } = null;

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



        /// <summary>
        /// Gets or sets the bill ID applied to the bill.
        /// </summary>
        [JsonPropertyName("billId")]
        public int? BillId { get; set; } = 0;
        /// <summary>
        /// Gets or sets the discount ID applied to the bill.
        /// </summary>
        [JsonPropertyName("discountId")]
        public int? DiscountId { get; set; } = 0;

        /// <summary>
        /// Gets or sets the mode of payment used.
        /// </summary>
        [JsonPropertyName("paymentMode")]
        public string PaymentMode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether parcel is required.
        /// </summary>
        [JsonPropertyName("isParcelRequired")]
        public bool? IsParcelRequired { get; set; } = false;

        /// <summary>
        /// Gets or sets the amount charged for parcel.
        /// </summary>
        [JsonPropertyName("parcelAmount")]
        public decimal? ParcelAmount { get; set; } = 0;
        /// <summary>
        /// Gets or sets the No of Person.
        /// </summary>
        [JsonPropertyName("noofPerson")]
        public int? NoofPerson { get; set; } = 0;

        /// <summary>
        /// Gets or sets the service charge amount.
        /// </summary>
        [JsonPropertyName("serviceCharge")]
        public decimal? ServiceCharge { get; set; } = 0;
        /// <summary>
        /// Gets or sets the sub total amount including only items charges.
        /// </summary>
        [JsonPropertyName("subTotal")]
        public decimal? SubTotal { get; set; } = 0;
        /// <summary>
        /// Gets or sets the SGST (State GST) amount.
        /// </summary>
        [JsonPropertyName("roundOff")]
        public decimal? RoundOff { get; set; } = 0;
        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        [JsonPropertyName("discountAmount")]
        public decimal? DiscountAmount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the net amount after discounts and charges.
        /// </summary>
        [JsonPropertyName("netAmount")]
        public decimal? NetAmount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the CGST (Central GST) amount.
        /// </summary>
        [JsonPropertyName("cgst")]
        public decimal? Cgst { get; set; } = 0;

        /// <summary>
        /// Gets or sets the SGST (State GST) amount.
        /// </summary>
        [JsonPropertyName("sgst")]
        public decimal? Sgst { get; set; } = 0;

        /// <summary>
        /// Gets or sets the total amount including all charges.
        /// </summary>
        [JsonPropertyName("grandTotal")]
        public decimal? GrandTotal { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether the payment is completed.
        /// </summary>
        [JsonPropertyName("isPaymentDone")]
        public bool? IsPaymentDone { get; set; } = false;
        [JsonPropertyName("tokenNumbers")]
        public string TokenNumbers { get; set; }=  string.Empty;

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

        [JsonPropertyName("itemComment")]
        public string? ItemComment { get; set; } = string.Empty;

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
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        ///// <summary>
        ///// Indicates if the saved order is printed.
        ///// </summary>
        //[JsonPropertyName("isSavePrint")]
        //public bool IsSavePrint { get; set; } = false;

        ///// <summary>
        ///// Indicates if it's a KOT (Kitchen Order Ticket) item.
        ///// </summary>
        //[JsonPropertyName("isKOT")]
        //public bool IsKOT { get; set; } = false;

        ///// <summary>
        ///// Indicates if the KOT is printed.
        ///// </summary>
        //[JsonPropertyName("isKOTPrint")]
        //public bool IsKOTPrint { get; set; } = false;

        ///// <summary>
        ///// Indicates if the order is on hold.
        ///// </summary>
        //[JsonPropertyName("isHold")]
        //public bool IsHold { get; set; } = false;

        ///// <summary>
        ///// Indicates if the order is saved for e-bill.
        ///// </summary>
        //[JsonPropertyName("isSaveEBill")]
        //public bool IsSaveEBill { get; set; } = false;

        ///// <summary>
        ///// Indicates if the order is completed.
        ///// </summary>
        //[JsonPropertyName("isOrderCompleted")]
        //public bool IsOrderCompleted { get; set; } = false;

        ///// <summary>
        ///// Indicates if the food is Received.
        ///// </summary>
        //[JsonPropertyName("isFoodReceived")]
        //public bool IsFoodReceived { get; set; } = false;
        

        /// <summary>
        /// Indicates if the order item is active.
        /// </summary>
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;
        [JsonPropertyName("isKotPrint")]
        public bool IsKotPrint { get; set; } 

    }
    
    public class UpdateFoodReceivedRequestDto
    {
        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the comma-separated item IDs (e.g., "2,3,1").
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether the food is received.
        /// </summary>
        [JsonPropertyName("isFoodReceived")]
        public bool IsFoodReceived { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether this is a checkout action.
        /// </summary>
        [JsonPropertyName("isCheckOut")]
        public bool IsCheckOut { get; set; } = false;
        [JsonPropertyName("review")]
        public string? Review { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the modified by username.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
