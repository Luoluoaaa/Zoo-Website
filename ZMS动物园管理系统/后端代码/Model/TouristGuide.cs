using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TouristGuide
    {
        public TouristGuide()
        {
            TourGuides = new HashSet<TourGuide>();
            TourProjs = new HashSet<TourProj>();
        }

        public string Id { get; set; }
        public string TourId { get; set; }
        public string GuideId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<TourGuide> TourGuides { get; set; }
        public virtual ICollection<TourProj> TourProjs { get; set; }
    }
}
