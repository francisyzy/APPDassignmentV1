using System;
using System.Collections.Generic;

namespace APPDassignmentV1.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public string ResourceId { get; set; }
        public string Email { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
