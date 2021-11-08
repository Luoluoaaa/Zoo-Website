using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class SciencePopularization
    {
        public SciencePopularization()
        {
            TourSciPops = new HashSet<TourSciPop>();
        }

        public string Name { get; set; }
        public string Species { get; set; }
        //public DateTime SleepingDuration { get; set; }
        //public string Habitat { get; set; }
        //public string FavoriteFood { get; set; }
        //public byte AverageHeight { get; set; }
        //public byte AverageWeight { get; set; }
        //public string ReproductionPattern { get; set; }
        public string Content { get; set; }
        public byte[] Img { get; set; }


        public virtual ICollection<TourSciPop> TourSciPops { get; set; }
    }
}
