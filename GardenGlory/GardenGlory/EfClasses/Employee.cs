using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string ExperienceLevelId { get; set; }
        public string EmployeeStatusId { get; set; }
        public string SupervisorId { get; set; }
        public string EmployeeTypeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CellPhone { get; set; }
        public string EmployeeFullName => $"{LastName}, {FirstName}";
        public double TotalHourrsWorked { get; set; }
        public bool IsDeleted { get; set; }

        //Relation 
        public ExperienceLevel ExperienceLevelLink { get; set; }

        public EmployeeStatus EmployeeStatusLink { get; set; }
        public  EmployeeType EmployeeTypeLink { get; set; }

        public Employee EmployeeLink { get; set; }

        public  ICollection<Account> Accounts { get; set; }
        public  ICollection<Task> Tasks { get; set; }
        public ICollection<TrainedEmployee> TrainedEmployees { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
