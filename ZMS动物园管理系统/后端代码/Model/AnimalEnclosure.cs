using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class AnimalEnclosure
    {
        public string AreaId { get; set; }
        public short AnimalCapacity { get; set; }
        public short CurrentHumidit { get; set; }
        public byte CurrentSound { get; set; }
        public byte CurrentTemp { get; set; }
        public string VisitMode { get; set; }
        public byte SecuirtyLevel { get; set; }
    }
}
