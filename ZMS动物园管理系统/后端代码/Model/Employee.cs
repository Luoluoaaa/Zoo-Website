using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Employee
    {
        public Employee()
        {
            AssessmentEmployees = new HashSet<Assessment>();
            AssessmentManagers = new HashSet<Assessment>();
            CureInformations = new HashSet<CureInformation>();
            FundAccounts = new HashSet<FundAccount>();
            ShowInformations = new HashSet<ShowInformation>();
            TrainInformations = new HashSet<TrainInformation>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public decimal Age { get; set; }
        public int Wage { get; set; }
        public string Position { get; set; }
        public string Park { get; set; }
        public DateTime EmploymentYear { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Assessment> AssessmentEmployees { get; set; }
        public virtual ICollection<Assessment> AssessmentManagers { get; set; }
        public virtual ICollection<CureInformation> CureInformations { get; set; }
        public virtual ICollection<FundAccount> FundAccounts { get; set; }
        public virtual ICollection<ShowInformation> ShowInformations { get; set; }
        public virtual ICollection<TrainInformation> TrainInformations { get; set; }
    }
}
