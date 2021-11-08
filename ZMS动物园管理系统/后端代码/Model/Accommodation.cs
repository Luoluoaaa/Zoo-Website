using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Accommodation
    {
        public Accommodation()
        {
            TourAccoms = new HashSet<TourAccom>();
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public short Price { get; set; }
        public byte? Mark { get; set; }
        public long PhoneNumeric { get; set; }

        public virtual ICollection<TourAccom> TourAccoms { get; set; }
    }
}
