using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TourShowTicket
    {
        public string TicketId { get; set; }
        public string TourId { get; set; }

        public virtual Tourist Ticket { get; set; }
        public virtual ShowTicket Tour { get; set; }
    }
}
