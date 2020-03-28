using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class EquipmentUsageDefaultValueGenerator
    {
        private GardenGloryContext _context;

        public EquipmentUsageDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }
        public string EquipmentUsagePrimaryKeyGenerator()
        {
            var context = new GardenGloryContext();
            var key  = new StringBuilder();
            var  num = (context.EquipmentUsages.Count() + 1).ToString();
            key = new StringBuilder();
            key.Append("EQU ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
    }
}
