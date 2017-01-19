using System;
using System.Collections.Generic;

namespace APPDassignmentV1.Models
{
    public partial class ResourceType
    {
        public ResourceType()
        {
            Resource = new HashSet<Resource>();
        }

        public int ResourceTypeId { get; set; }
        public string ResourceTypeName { get; set; }

        public virtual ICollection<Resource> Resource { get; set; }
    }
}
