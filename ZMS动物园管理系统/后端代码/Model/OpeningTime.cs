using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class OpeningTime
    {
        public bool Day { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
