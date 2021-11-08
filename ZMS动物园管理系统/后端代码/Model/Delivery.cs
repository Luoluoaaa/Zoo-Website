using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Delivery
    {
        public string AnimalId { get; set; }
        public DateTime Time { get; set; }
        public string EmployeeId { get; set; }
    }
}
