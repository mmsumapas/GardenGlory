using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class PropertyDescriptionDefaultValueGenerator
    {
        private GardenGloryContext _context;

        public PropertyDescriptionDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }

        public string PropertyDescriptionPrimaryKeyGenerator()
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.PropertyDescriptions.Count() + 1).ToString();

            key.Append("PPD ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
    }
}
