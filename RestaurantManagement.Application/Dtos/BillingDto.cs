using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Dtos
{
    public class BillingDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the bill.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the associated order ID.
        /// </summary>
        [JsonPropertyName("orderId")]
        public int? OrderId { get; set; }
        /// <summary>
        /// Gets or sets the associated table ID.
        /// </summary>
        [JsonPropertyName("tableId")]
        public int? TableId { get; set; }
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
        /// Gets or sets the discount ID applied to the bill.
        /// </summary>
        [JsonPropertyName("discountId")]
        public int? DiscountId { get; set; }

        /// <summary>
        /// Gets or sets the mode of payment used.
        /// </summary>
        [JsonPropertyName("paymentMode")]
        public string PaymentMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether parcel is required.
        /// </summary>
        [JsonPropertyName("isParcelRequired")]
        public bool? IsParcelRequired { get; set; }

        /// <summary>
        /// Gets or sets the amount charged for parcel.
        /// </summary>
        [JsonPropertyName("parcelAmount")]
        public decimal? ParcelAmount { get; set; }

        /// <summary>
        /// Gets or sets the service charge amount.
        /// </summary>
        [JsonPropertyName("serviceCharge")]
        public decimal? ServiceCharge { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        [JsonPropertyName("discountAmount")]
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets the net amount after discounts and charges.
        /// </summary>
        [JsonPropertyName("netAmount")]
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// Gets or sets the CGST (Central GST) amount.
        /// </summary>
        [JsonPropertyName("cgst")]
        public decimal? Cgst { get; set; }

        /// <summary>
        /// Gets or sets the SGST (State GST) amount.
        /// </summary>
        [JsonPropertyName("sgst")]
        public decimal? Sgst { get; set; }
        /// <summary>
        /// Gets or sets the SGST (State GST) amount.
        /// </summary>
        [JsonPropertyName("roundOff")]
        public decimal? RoundOff { get; set; }

        /// <summary>
        /// Gets or sets the total amount including all charges.
        /// </summary>
        [JsonPropertyName("grandTotal")]
        public decimal? GrandTotal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the payment is completed.
        /// </summary>
        [JsonPropertyName("isPaymentDone")]
        public bool? IsPaymentDone { get; set; }

        /// <summary>
        /// Gets or sets the name of the user who created the record.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the creation date and time.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the user who last modified the record.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the last modification date and time.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }
}
