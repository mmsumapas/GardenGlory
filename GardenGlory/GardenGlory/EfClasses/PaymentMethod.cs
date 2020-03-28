using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class PaymentMethod
    {
        public string PaymentMethodId { get; set; }
        public string Method { get; set; } //Online payment or on cash payment 
        public string MethodName => $"{Method}";

        //Relation 
        public  ICollection<Payment> Payments { get; set; }
    }
}
