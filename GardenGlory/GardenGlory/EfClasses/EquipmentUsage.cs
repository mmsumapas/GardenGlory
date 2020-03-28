using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class EquipmentUsage
    {
        public string EquipmentUsageId { get; set; }
        public string EquipmentId { get; set; }
        public string TaskId { get; set; }
        public string UsageDescription { get; set; }

        //Relation 
        public  Equipment EquipmentLink { get; set; }
        public  Task TaskLink { get; set; }

    }
}
