using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            UserCoupons = new HashSet<UserCoupon>();
        }

        public uint Id { get; set; }
        public uint Amount { get; set; }

        public virtual ICollection<UserCoupon> UserCoupons { get; set; }
    }
}
