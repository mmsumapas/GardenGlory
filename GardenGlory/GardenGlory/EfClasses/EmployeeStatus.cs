using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class EmployeeStatus
    {
        public  string EmployeeStatusId { get; set; }
        public string Status { get; set; } //Full time or part time 
        public string EmployeeStatusName => $"{Status}";

        //Relation 
        public ICollection<Employee> Employees { get; set; }
    }
}
