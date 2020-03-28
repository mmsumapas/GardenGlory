using GardenGlory.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{ 
    public class PaymentDataGenerate
    {
        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var payments =
                Payments_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\Payment\Payment.CSV");

            using var context = new GardenGloryContext();
            foreach (var payment in payments)
            { 
                context.Add(payment);
                context.SaveChanges();
            }
        }

        private IList<Payment> Payments_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listPayments = new List<Payment>();

            string s = sr.ReadLine();


            while (s != null)
            {
                var split = s.Split(',');
                var dateSplit = split[2].Split('/');
                var date = new DateTime(Convert.ToInt32(dateSplit[2]), Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]));

                var newPayment = new Payment
                {
                    ServiceId = split[0],
                    PaymentMethodId = split[1],
                    Date = date,
                    Amount = Convert.ToDouble(split[3]),
                };

                listPayments.Add(newPayment);
                s = sr.ReadLine();
            }
            return listPayments;
        }
    }
}

