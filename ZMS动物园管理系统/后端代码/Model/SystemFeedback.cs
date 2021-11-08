using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class SystemFeedback
    {
        public string Id { get; set; }
        public string TourId { get; set; }
        public string FeedbackContent { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

    }
}
