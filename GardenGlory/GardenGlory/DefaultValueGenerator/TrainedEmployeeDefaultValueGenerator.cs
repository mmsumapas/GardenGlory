using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class TrainedEmployeeDefaultValueGenerator
    {
        private GardenGloryContext _context;

        public TrainedEmployeeDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }

        public string TrainedEmployeePrimaryKeyGenerator()
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.TrainedEmployees.Count() + 1).ToString();

            key.Append("TEMP ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
    }

}
