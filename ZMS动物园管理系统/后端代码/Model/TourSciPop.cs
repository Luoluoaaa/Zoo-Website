using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TourSciPop
    {
        public string TourId { get; set; }
        public string AnimalCategory { get; set; }

        public virtual SciencePopularization AnimalCategoryNavigation { get; set; }
        public virtual Tourist Tour { get; set; }
    }
}
