using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class FundAccount
    {
        public string FundAccId { get; set; }
        public string Name { get; set; }
        public DateTime TransactionTime { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public string StaffId { get; set; }
        public string BankAccId { get; set; }
        public string Note { get; set; }

        public virtual Employee StaffIDNavigation { get; set; }
        public virtual BankAccount BankAccIdNavigation { get; set; }
    }
}
