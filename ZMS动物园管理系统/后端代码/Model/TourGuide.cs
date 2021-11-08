using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TourGuide
    {
        public string TourId { get; set; }
        public string OrderNumber { get; set; }

        public virtual TouristGuide OrderNumberNavigation { get; set; }
        public virtual Tourist Tour { get; set; }
    }
}
