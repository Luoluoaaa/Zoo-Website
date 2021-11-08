using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Recipe
    {
        public string Id { get; set; }
        public string Species { get; set; }
        public string FoodList1 { get; set; }
        public short FoodWeight1 { get; set; }
        public string FoodList2 { get; set; }
        public short? FoodWeight2 { get; set; }
        public string FoodList3 { get; set; }
        public short? FoodWeight3 { get; set; }
        public string FoodList4 { get; set; }
        public short? FoodWeight4 { get; set; }
    }
}
