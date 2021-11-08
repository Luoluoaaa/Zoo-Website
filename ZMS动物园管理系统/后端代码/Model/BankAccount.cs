using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            FundAccounts = new HashSet<FundAccount>();
        }

        public string BankAccId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string StaffId { get; set; }
        public virtual ICollection<FundAccount> FundAccounts { get; set; }

    }
}
