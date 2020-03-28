using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{
    public class ServiceDataGenerate
    {

        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var services = 
                Services_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\Service\Service.CSV");

            using var context = new GardenGloryContext();
            foreach (var service in services)
            {
                context.Add(service);
                context.SaveChanges();
            }
        }

        private IList<Service> Services_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listServices = new List<Service>();

            string s = sr.ReadLine();


            while (s != null)
            {
                var split = s.Split(',');
                var dateSplit = split[2].Split('/');
                var date = new DateTime(Convert.ToInt32(dateSplit[2]), Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]) );

                var newService = new Service
                {
                    PropertyId = split[0],
                    ServiceTypeId = split[1],
                    RequestDate = date,
                    ServiceRequest = split[3]
                };

                listServices.Add(newService);
                s = sr.ReadLine();
            }
            return listServices;
        }
    }
}

