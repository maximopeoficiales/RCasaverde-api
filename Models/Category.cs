using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
