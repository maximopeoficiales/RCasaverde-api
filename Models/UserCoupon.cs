using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class UserCoupon
    {
        public ulong IdClient { get; set; }
        public uint IdCoupon { get; set; }
        public sbyte Used { get; set; }

        public virtual User IdClientNavigation { get; set; }
        public virtual Coupon IdCouponNavigation { get; set; }
    }
}
