using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class ShowTicket
    {
        public ShowTicket()
        {
            TourShowTickets = new HashSet<TourShowTicket>();
        }

        public string Id { get; set; }
        public string ShowId { get; set; }
        public string TicketType { get; set; }
        public string Tourid { get; set; }

        public virtual ICollection<TourShowTicket> TourShowTickets { get; set; }
    }
}
