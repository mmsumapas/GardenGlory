using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class EmployeeDefaultValueGenerator
    {
        private GardenGloryContext _context;
        public EmployeeDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }
        public string EmployeePrimaryKeyGenerator()
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Employees.Count() + 1).ToString();

            key.Append("EMP ");
            key.Append(DateTime.Now.Year.ToString());
            key.Append($" {num.PadLeft(6, '0')}");
            return key.ToString();
        }
    }
}
