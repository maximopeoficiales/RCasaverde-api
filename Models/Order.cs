using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            OrderHistories = new HashSet<OrderHistory>();
        }

        public ulong Id { get; set; }
        public ulong IdClient { get; set; }
        public decimal Total { get; set; }
        public uint? Zipcode { get; set; }
        public string ShippingAddress { get; set; }
        public string Reference { get; set; }
        public string Message { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public uint IdOrderStatus { get; set; }
        public uint IdPaymentType { get; set; }
        public uint IdDocumentType { get; set; }

        public virtual User IdClientNavigation { get; set; }
        public virtual DocumentType IdDocumentTypeNavigation { get; set; }
        public virtual OrderStatus IdOrderStatusNavigation { get; set; }
        public virtual PaymentType IdPaymentTypeNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
