using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class PropertyDefaultValueGenerator
    {
        private GardenGloryContext _context;

        public PropertyDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;

        }

        public string PropertyPrimaryKeyGenerator()
        {
            var key = new StringBuilder();

            var num = (_context.Properties.Count() + 1).ToString();

            key.Append("PP ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
    }
}
