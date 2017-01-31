using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPDassignmentV1.Models
{
    public partial class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }  
        public DateTime BookingDate { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public string ResourceId { get; set; }
        public string Email { get; set; }

        public virtual Resource Resource { get; set; }
    }

    
}
