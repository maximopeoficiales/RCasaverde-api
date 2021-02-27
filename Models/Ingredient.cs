using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            Recipes = new HashSet<Recipe>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public decimal StockKg { get; set; }
        public decimal StockKgMin { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
