using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Feed
    {
        public string AnimalId { get; set; }
        public string KeeperId { get; set; }
        public string FoodId { get; set; }
        public DateTime Day { get; set; }
        public string Note { get; set; }
    }
}
