using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class Task
    {
        public string TaskId { get; set; }
        public string EmployeeId { get; set; }
        public string ServiceId { get; set; }
        public DateTime DateConducted { get; set; }
        public double HoursWorked { get; set; }
        public string TaskName { get; set; }
        
        //Relation 
        public Service ServiceLink { get; set; }
        public Employee EmployeeLink { get; set; }

        public ICollection<EquipmentUsage> EquipmentUsages { get; set; }
    }
}
