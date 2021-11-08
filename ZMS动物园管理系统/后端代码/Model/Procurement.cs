using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Procurement
    {
        public string ProcureId { get; set; }
        public string Name { get; set; }
        public DateTime ProcureDate { get; set; }
        public string Status { get; set; }
        public string StaffId { get; set; }
        public decimal Budget { get; set; }
        public string Remarks { get; set; }
    }
}
