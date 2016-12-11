using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPDassignmentV1.House
{

    public class ResourceData
    {
        public List<unitResource> unitResources { get; set; }
        public List<roomResource> roomResources { get; set; }
        public List<facility> facilities { get; set; }
    }
    public abstract class Resource
    {
        
        public string resourceId { get; set; }
        public address address { get; set; } //maybe call in map api to look up MRT
        public double price { get; set; }
        public int resourceType { get; set; } //1 = unit || 2= room

    }
    
    public class unitResource:Resource
    {
        public int unitId { get; set; }
        public int houseSize { get; set; }
        public List<facility> facilities { get; set; }
        public int roomCount { get; set; }
        public int aircon { get; set; }
    }

    public class roomResource:Resource
    {
        public int roomId { get; set; }
        public int roomSize { get; set; }
        public Boolean aircon { get; set; }
        
        
    }

    public class facility
    {
        public int facilityTypeId { get; set; }
        public string facilityTypeName { get; set; }
        

    }

    public class address
    {
        public int postalCode { get; set; }
        public string fullAddress { get; set; }
        public string region { get; set; }
    }
}
