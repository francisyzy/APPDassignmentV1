using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPDassignmentV1.House
{
    public abstract class Resource
    {
        public string resourceId { get; set; }
        public string fullAddress { get; set; }
        public double price { get; set; }
        public string region { get; set; }

    }
    
    public class unitResource
    {
        public int unitId { get; set; }
        public int houseSize { get; set; }
        public string facilities { get; set; }
        public int roomCount { get; set; }
        public int aircon { get; set; }
    }

    public class RoomResource
    {
        public int roomId { get; set; }
        public int roomSize { get; set; }
        public Boolean aircon { get; set; }
    }
}
