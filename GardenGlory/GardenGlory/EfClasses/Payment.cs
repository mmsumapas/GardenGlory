using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class Payment
    {
        public string PaymentId { get; set; }
        public string ServiceId { get; set; }
        public string PaymentMethodId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        //Relation 
        public Service ServiceLink { get; set; }
        public PaymentMethod PaymentMethodLink { get; set; }
       
    }
}
