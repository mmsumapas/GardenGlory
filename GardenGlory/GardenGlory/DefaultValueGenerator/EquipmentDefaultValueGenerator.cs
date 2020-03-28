using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class EquipmentDefaultValueGenerator
    {
        private GardenGloryContext _context;
        public EquipmentDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }

        public string EquipmentPrimaryKeyValueGenerator()
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Equipments.Count() + 1).ToString();

            key.Append("EQ ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
    }
}
