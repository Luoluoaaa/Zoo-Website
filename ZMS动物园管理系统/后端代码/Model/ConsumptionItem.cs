using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class ConsumptionItem
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public string EventContect { get; set; }
        public string EventLocation { get; set; }
        public short EventPrice { get; set; }
    }
}
