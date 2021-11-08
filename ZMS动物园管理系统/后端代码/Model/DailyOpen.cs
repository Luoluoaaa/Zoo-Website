using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class DailyOpen
    {
        public string AreaId { get; set; }
        public bool Day { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
