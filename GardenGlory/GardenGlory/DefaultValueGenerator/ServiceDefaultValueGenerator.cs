using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class ServiceDefaultValueGenerator
    {
        private GardenGloryContext _context;

        public ServiceDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }

        public string ServicePrimaryKeyGenerator()
        {
            var key = new StringBuilder();

            var num = (_context.Services.Count() + 1).ToString();

            key.Append("SV ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
    }
}
