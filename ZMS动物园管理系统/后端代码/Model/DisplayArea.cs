using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class DisplayArea
    {
        public string AreaId { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string Zone { get; set; }
        public string Location { get; set; }
        public decimal AdditionalFee { get; set; }
        public string Telephone { get; set; }
        public decimal TouristCapacity { get; set; }
        public string Status { get; set; }
    }
}
