using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Orders = new HashSet<Order>();
        }

        public uint Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
