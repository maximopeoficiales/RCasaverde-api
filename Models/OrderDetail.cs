using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class OrderDetail
    {
        public ulong IdOrder { get; set; }
        public uint IdProduct { get; set; }
        public uint Quantity { get; set; }

        public virtual Order IdOrderNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
