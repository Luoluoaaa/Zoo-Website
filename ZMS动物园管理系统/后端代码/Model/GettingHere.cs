using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class GettingHere
    {
        public GettingHere()
        {
            TourHeres = new HashSet<TourHere>();
        }

        public string Id { get; set; }
        public string VehicleCategory { get; set; }
        public decimal DepartureInterval { get; set; }
        public decimal TransDuration { get; set; }
        public decimal Price { get; set; }
        public string BoardingLocation { get; set; }

        public virtual ICollection<TourHere> TourHeres { get; set; }
    }
}
