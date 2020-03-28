using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{
    public class EquipmentUsageDataGenerate
    {
        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var equipmentUsages =
                EquipmentUsages_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\EquipmentUsage\EquipmentUsage.CSV");

            using var context = new GardenGloryContext();
            foreach (var equipmentUsage in equipmentUsages)
            {
                context.Add(equipmentUsage);
                context.SaveChanges();
            }
        }

        private IList<EquipmentUsage> EquipmentUsages_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listEquipmentUsages = new List<EquipmentUsage>();

            string s = sr.ReadLine();

            while (s != null)
            {
                var split = s.Split(',');

                var newEquipmentUsage = new EquipmentUsage
                {
                    EquipmentId = split[0],
                    TaskId = split[1],
                    UsageDescription = split[2]
                    
                };

                listEquipmentUsages.Add(newEquipmentUsage);
                s = sr.ReadLine();
            }
            return listEquipmentUsages;
        }
    }
}

