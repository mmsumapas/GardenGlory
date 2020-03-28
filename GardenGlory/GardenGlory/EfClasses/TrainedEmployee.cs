using System;
using System.Collections.Generic;
using System.Text;
using GardenGlory.EfClasses;

namespace GardenGlory
{
    public class TrainedEmployee
    {
        public string TrainedEmployeeId { get; set; }
        public string EmployeeId { get; set; }
        public string EquipmentId { get; set; }

        //Relation 
        public Equipment EquipmentLink { get; set; }
        public Employee EmployeeLink { get; set; }
    }
}
