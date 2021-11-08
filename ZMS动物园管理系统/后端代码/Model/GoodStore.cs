using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class GoodStore
    {
        public string StoreId { get; set; }
        public string ItemId { get; set; }
        public decimal ItemCounts { get; set; }
    }
}
