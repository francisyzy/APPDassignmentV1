using System;
using System.Collections.Generic;

namespace APPDassignmentV1.Models
{
    public partial class Picture
    {
        public Picture()
        {
            Resource = new HashSet<Resource>();
        }

        public int PictureId { get; set; }
        public byte[] Picturee { get; set; }

        public virtual ICollection<Resource> Resource { get; set; }
    }
}
