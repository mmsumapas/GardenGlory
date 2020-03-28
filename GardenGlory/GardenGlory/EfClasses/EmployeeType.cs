using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class EmployeeType
    {
        public string EmployeeTypeId { get; set; }
        public string Type { get; set; } //Gardener, Manager, finance, etc. 
        public string EmployeeTypeName => $"{Type}";

        //Relation 
        public ICollection<Employee> Employees { get; set; }
    }
}
