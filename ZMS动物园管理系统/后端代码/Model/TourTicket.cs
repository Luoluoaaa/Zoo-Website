using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TourTicket
    {
        public string TourId { get; set; }
        public string TicketId { get; set; }

        public virtual AdmissionTicket Ticket { get; set; }
        public virtual Tourist Tour { get; set; }
    }
}
