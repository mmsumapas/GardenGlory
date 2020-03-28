using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class PaymentDefaultValueGenerator
    {
        private GardenGloryContext _context;

        public PaymentDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }
        public string PaymentPrimaryKeyGenerator()
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Payments.Count() + 1).ToString();

            key.Append("PY ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
    }
}
