using System;
using System.Collections.Generic;

namespace APPDassignmentV1.Models
{
    public partial class Resource
    {
        public Resource()
        {
            Booking = new HashSet<Booking>();
        }

        public string ResourceId { get; set; }
        public int PostalCode { get; set; }
        public string Fulladdress { get; set; }
        public int RegionId { get; set; }
        public short Price { get; set; }
        public int ResourceTypeId { get; set; }
        public short ResourceSize { get; set; }
        public byte Aircon { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        
        public virtual Region Region { get; set; }
        public virtual ResourceType ResourceType { get; set; }
    }
}
