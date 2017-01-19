using System;
using System.Collections.Generic;

namespace APPDassignmentV1.Models
{
    public partial class Region
    {
        public Region()
        {
            Resource = new HashSet<Resource>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public virtual ICollection<Resource> Resource { get; set; }
    }
}
