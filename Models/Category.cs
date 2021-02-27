using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public sbyte Active { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
