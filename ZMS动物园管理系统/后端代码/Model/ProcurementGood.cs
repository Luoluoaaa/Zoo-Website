using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class ProcurementGood
    {
        public string ProcureId { get; set; }
        public string ItemId { get; set; }
        public decimal ItemCount { get; set; }
    }
}
