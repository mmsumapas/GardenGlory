using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{
    public class OwnerDataGenerate
    {
        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var owners =
                Owners_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\Owner\Owner.CSV");

            using var context = new GardenGloryContext();
            foreach (var owner in owners)
            {
                context.Add(owner);
                context.SaveChanges();
            }
        }

        private IList<Owner> Owners_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listOwners = new List<Owner>();

            string s = sr.ReadLine();

            while (s != null)
            {
                var split = s.Split(',');
                // var birthdate = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[0]), Convert.ToInt32(date[1]));

                var newOwner = new Owner
                {
                    OwnerTypeId = split[0],
                    OwnerName = split[1],
                    OwnerEmail = split[2],
                    ContactNumber = split[3]
                };

                listOwners.Add(newOwner);
                s = sr.ReadLine();
            }
            return listOwners;
        }
    }
}
