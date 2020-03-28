using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class Equipment
    {
        public string EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public bool IsDeleted { get; set; }
        public string EquipmentNameString => $"{EquipmentName}";

        //Relation 
        public ICollection<EquipmentUsage> EquipmentUsages { get; set; }
        public ICollection<TrainedEmployee> TrainedEmployees { get; set; }
        public ICollection<EquipmentRepair> EquipmentRepairs { get; set; }

    }
}
