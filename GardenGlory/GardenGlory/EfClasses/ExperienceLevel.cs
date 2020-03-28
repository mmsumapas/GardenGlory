using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class ExperienceLevel
    {
        public string ExperienceLevelId { get; set; }
        public string Level { get; set; }
        public string ExperienceLevelName => $"{Level}";

        //Relation 
        public ICollection<Employee> Employees { get; set; }
    }
}
