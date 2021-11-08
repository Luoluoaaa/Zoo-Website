using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class TourAround
    {
        public string Id { get; set; }
        public string OrderId { get; set; }

        public virtual Tourist IdNavigation { get; set; }
        public virtual GettingAroundZoo Order { get; set; }
    }
}
