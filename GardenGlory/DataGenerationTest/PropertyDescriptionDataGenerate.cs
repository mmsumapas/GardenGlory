using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{
    public class PropertyDescriptionDataGenerate
    {
        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var propertyDescriptions =
                PropertyDescriptions_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\PropertyDescription\PropertyDescription.CSV");

            using var context = new GardenGloryContext();
            foreach (var propertyDescription in propertyDescriptions)
            {
                context.Add(propertyDescription);
                context.SaveChanges();
            }
        }

        private IList<PropertyDescription> PropertyDescriptions_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listPropertyDescriptions = new List<PropertyDescription>();

            string s = sr.ReadLine();

            while (s != null)
            {
                var split = s.Split(',');
                var newPropertyDescription = new PropertyDescription
                {
                    PropertyId = split[0],
                    Description = split[1],
                };

                listPropertyDescriptions.Add(newPropertyDescription);
                
                s = sr.ReadLine();
            }
            return listPropertyDescriptions;
        }
    }
}

