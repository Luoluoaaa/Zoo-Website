using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Assessment
    {
        public string EmployeeId { get; set; }
        public string ManagerId { get; set; }
        public DateTime AssessmentTime { get; set; }
        public string AssessmentGrade { get; set; }
        public string Remarks { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employee Manager { get; set; }
    }
}
