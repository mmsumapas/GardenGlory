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
    public class PropertyDataGenerate
    {
        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var properties =
                Properties_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\Property\Property1.CSV");
            
            using var context = new GardenGloryContext();
            foreach (var property in properties)
            {
                context.Add(property);
                context.SaveChanges();
            }
        }

        private IList<Property> Properties_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listProperties = new List<Property>();

            string s = sr.ReadLine();

            while (s != null)
            {
                var split = s.Split(',');
                if (split.Length<6)
                {
                    var newOwner = new Property
                    {
                        OwnerId = split[0],
                        PropertyName = split[1],
                        Street = split[2],
                        City = split[3],
                        Zip = split[4]
                    };
                    listProperties.Add(newOwner);
                }
                else
                {
                    var newProperty = new Property
                    {
                        ParentPropertyId = split[0],
                        OwnerId = split[1],
                        PropertyName = split[2],
                        Street = split[3],
                        City = split[4],
                        Zip = split[5]
                    };
                    listProperties.Add(newProperty);
                }
                s = sr.ReadLine();  
            }
            return listProperties;
        }
    }
}
