using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class TaskDefaultValueGenerator
    {
        private GardenGloryContext _context;

        public TaskDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }
        public string TaskPrimaryKeyGenerator()
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Tasks.Count() + 1).ToString();

            key.Append("TK ");
            key.Append($"{num.PadLeft(3, '0')}");
            return key.ToString();
        }
    }
}
