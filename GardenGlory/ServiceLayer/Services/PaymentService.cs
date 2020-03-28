using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class PaymentService
    {
        private GardenGloryContext _context;

        //Get, add and update
        // Display when service is not deleted

        public PaymentService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<Payment> GetPayments()
        {
            return _context.Payments
                .Include(C => C.ServiceLink)
                .Include(c=>c.PaymentMethodLink);
        }
        public IQueryable<Payment> GetPayments(Service service)
        {
            return _context.Payments
                .Where(c=>c.ServiceId == service.ServiceId)
                .Include(C => C.ServiceLink)
                .Include(c=>c.PaymentMethodLink);
        }

        public void AddPayment(Payment payment)
        {
            using (var context = new GardenGloryContext())
            {
                _context.Payments.Add(payment);
                _context.SaveChanges();
            }
        }

        public void UpdatePayment(int paymentId, DateTime date, double amount)
        {
            var payment = _context.Payments.Find(paymentId);
            payment.Date = date;
            payment.Amount = amount;
            _context.SaveChanges();
        }
    }
}
