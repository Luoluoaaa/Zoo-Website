using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Animal
    {
        public string Id { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public int BodyLength { get; set; }
        public int Weight { get; set; }
        public string PhysicalCondition { get; set; }
        public byte[] Photo { get; set; }
        public string BreedSituation { get; set; }

        public virtual CureInformation CureInformation { get; set; }
    }
}
