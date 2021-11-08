using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Model
{
    public partial class Birth
    {
        public string Id { get; set; }
        public DateTime? Time { get; set; }
        public bool? Success { get; set; }
        public byte? ChildrenNum { get; set; }
    }
}
