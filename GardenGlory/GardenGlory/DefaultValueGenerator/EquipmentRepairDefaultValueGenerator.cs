using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.Migrations;

namespace GardenGlory.DefaultValueGenerator
{
    public class EquipmentRepairDefaultValueGenerator
    {
        private GardenGloryContext _context;

        public EquipmentRepairDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }

        public string EquipmentRepairPrimaryKeyGenerator()
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.EquipmentRepairs.Count() + 1).ToString();

            key.Append("EQR ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
    }
}
