using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class CustomerDefaultValueGenerator
    {
        private GardenGloryContext _context;
        public CustomerDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }

        public string CustomerPrimaryKeyGenerator()
        {
            var key = new StringBuilder();

            var num = (_context.Owners.Count() + 1).ToString();

            key.Append("ON ");
            key.Append($"{num.PadLeft(6, '0')}");

            return key.ToString();
        }
    }
}
