using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TrainInformation
    {
        public string Id { get; set; }
        public DateTime TrainDate { get; set; }
        public string Skill { get; set; }
        public string TrainerId { get; set; }
        public string TrainSite { get; set; }
        public string Props { get; set; }
        public string Remarks { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AnimalId { get; set; }

        public virtual Employee Trainer { get; set; }
    }
}
