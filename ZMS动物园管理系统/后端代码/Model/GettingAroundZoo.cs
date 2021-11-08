using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class GettingAroundZoo
    {
        public GettingAroundZoo()
        {
            TourArounds = new HashSet<TourAround>();
        }

        public string Id { get; set; }
        public string TourId { get; set; }
        public string VehicleCategory { get; set; }
        public decimal Price { get; set; }
        public string TicketType { get; set; }
        public DateTime date { get; set; }
        

        public virtual ICollection<TourAround> TourArounds { get; set; }
    }
}
