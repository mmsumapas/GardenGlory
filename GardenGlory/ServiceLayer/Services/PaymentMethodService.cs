using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class PaymentMethodService
    {
        private GardenGloryContext _context;

        //Get and update only
        //fix to two types only: Online or cash payment

        public PaymentMethodService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<PaymentMethod> GetPaymentMethods()
        {
            return _context.PaymentMethods;
        }

        public void UpdatePaymentMethod(int paymentMethodId, string method)
        {
            // do not allow the change in paymentId

            var paymentMethod = _context.PaymentMethods.Find(paymentMethodId);

            paymentMethod.Method = method;

            _context.SaveChanges();
        }
    }
}
