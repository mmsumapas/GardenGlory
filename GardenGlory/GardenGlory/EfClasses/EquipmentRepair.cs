using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
   public class EquipmentRepair
    {
        public string EquipmentRepairId { get; set; }
        public string EquipmentId { get; set; }
        public DateTime DateOfRepair { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; } 

        //Relation 
        public Equipment EquipmentLink { get; set; }
    }
}
