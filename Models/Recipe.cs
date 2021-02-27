using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Recipe
    {
        public uint IdProduct { get; set; }
        public uint IdIngredient { get; set; }
        public string Name { get; set; }
        public decimal QuantityKg { get; set; }

        public virtual Ingredient IdIngredientNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
