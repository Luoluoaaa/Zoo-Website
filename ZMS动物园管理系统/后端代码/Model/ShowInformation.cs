using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class ShowInformation
    {
        public string ShowId { get; set; }
       
        public string PrincipalName { get; set; }
        public string ShowSite { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowProps { get; set; }
        public DateTime StartTime { get; set; }
        public string ShowName { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Employee PrincipalNameNavigation { get; set; }
    }
}
