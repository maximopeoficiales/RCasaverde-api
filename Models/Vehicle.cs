using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            OrderHistories = new HashSet<OrderHistory>();
            TechnicalReviews = new HashSet<TechnicalReview>();
        }

        public string Id { get; set; }
        public uint IdSoat { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }

        public virtual Soat IdSoatNavigation { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
        public virtual ICollection<TechnicalReview> TechnicalReviews { get; set; }
    }
}
