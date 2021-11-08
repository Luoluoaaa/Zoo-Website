using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class CureInformation
    {
        public string CureId { get; set; }
        public string DiseaseName { get; set; }
        public string VeterinaryId { get; set; }
        public string Drug { get; set; }
        public decimal IsCured { get; set; }
        public DateTime DateIll { get; set; }
        public DateTime? DateCure { get; set; }
        public string AnimalId { get; set; }

        public virtual Animal animal { get; set; }
        public virtual Employee Veterinary { get; set; }
    }
}
