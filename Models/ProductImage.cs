using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class ProductImage
    {
        public uint Id { get; set; }
        public uint IdProduct { get; set; }
        public string ImgUrl { get; set; }

        public virtual Product IdProductNavigation { get; set; }
    }
}
