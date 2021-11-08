using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class AdmissionTicket
    {
        public AdmissionTicket()
        {
            TourTickets = new HashSet<TourTicket>();
        }

        public string Id { get; set; }
        public DateTime EnteringDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TourId { get; set; }
        public decimal Price { get; set; }
        public string TicketType { get; set; }

        public virtual ICollection<TourTicket> TourTickets { get; set; }
    }
}
