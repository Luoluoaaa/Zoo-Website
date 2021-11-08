using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Tourist
    {
        public Tourist()
        {
            TourAccoms = new HashSet<TourAccom>();
            TourArounds = new HashSet<TourAround>();
            TourGuides = new HashSet<TourGuide>();
            TourHeres = new HashSet<TourHere>();
            TourProjs = new HashSet<TourProj>();
            TourSciPops = new HashSet<TourSciPop>();
            TourShowTickets = new HashSet<TourShowTicket>();
            TourTickets = new HashSet<TourTicket>();
        }

        public string Id { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Mailbox { get; set; }
        public string IDcard { get; set; }

        public virtual ICollection<TourAccom> TourAccoms { get; set; }
        public virtual ICollection<TourAround> TourArounds { get; set; }
        public virtual ICollection<TourGuide> TourGuides { get; set; }
        public virtual ICollection<TourHere> TourHeres { get; set; }
        public virtual ICollection<TourProj> TourProjs { get; set; }
        public virtual ICollection<TourSciPop> TourSciPops { get; set; }
        public virtual ICollection<TourShowTicket> TourShowTickets { get; set; }
        public virtual ICollection<TourTicket> TourTickets { get; set; }
    }
}
