using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Good
    {
        public string ItemId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Target { get; set; }
        public string Channel { get; set; }
        public string StoreCondition { get; set; }
        public string UsageMethod { get; set; }
        public string StaffId { get; set; }
        public string Remark { get; set; }
    }
}
