using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductImages = new HashSet<ProductImage>();
            Recipes = new HashSet<Recipe>();
            UserReviews = new HashSet<UserReview>();
        }

        public uint Id { get; set; }
        public uint IdCategory { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public decimal SellPrice { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }
        public int? Stars { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public string Active { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<UserReview> UserReviews { get; set; }
    }
}
