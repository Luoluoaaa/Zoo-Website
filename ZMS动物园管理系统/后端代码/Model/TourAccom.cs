using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TourAccom
    {
        public string TourId { get; set; }
        public string HotelName { get; set; }

        public virtual Accommodation HotelNameNavigation { get; set; }
        public virtual Tourist Tour { get; set; }
    }
}
