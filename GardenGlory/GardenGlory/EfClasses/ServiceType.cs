using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class ServiceType
    {
        public string ServiceTypeId { get; set; }
        public string Type { get; set; }
        public string ServiceTypeName => $"{Type}";

        //Relation 
        public ICollection<Service> Services { get; set; }

    }
}
