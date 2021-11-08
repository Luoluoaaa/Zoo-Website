using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TourProj
    {
        public string TourId { get; set; }
        public string ProjectId { get; set; }
        public DateTime ParticipationDate { get; set; }
        public string Job { get; set; }

        public virtual TouristGuide Project { get; set; }
        public virtual Tourist Tour { get; set; }
    }
}
