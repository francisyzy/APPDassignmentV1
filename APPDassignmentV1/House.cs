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
        public address Address { get; set; }
        public double price { get; set; }
        public string region { get; set; }

    }
    
    public class unitResource:Resource
    {
        public int unitId { get; set; }
        public int houseSize { get; set; }
        public List<facilities> Facility { get; set; }
        public int roomCount { get; set; }
        public int aircon { get; set; }
    }

    public class RoomResource:Resource
    {
        public int roomId { get; set; }
        public int roomSize { get; set; }
        public Boolean aircon { get; set; }
        
    }

    public class facilities
    {
        public int facilityTypeID { get; set; }
        public string facilityTypeName { get; set; }
        

    }

    public class address
    {
        public int postcode { get; set; }
        public string fullAddress { get; set; }
    }
}
