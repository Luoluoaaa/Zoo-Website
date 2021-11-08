using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TourHere
    {
        public string TourId { get; set; }
        public string VehicleCategory { get; set; }
        public string VehicleId { get; set; }

        public virtual Tourist Tour { get; set; }
        public virtual GettingHere Vehicle { get; set; }
    }
}
