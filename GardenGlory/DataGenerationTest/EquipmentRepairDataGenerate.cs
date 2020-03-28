using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{
    public class EquipmentRepairDataGenerate
    {

        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var equipmentRepairs =
                EquipmentRepairs_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\EquipmentRepair\EquipmentRepair.CSV");

            using var context = new GardenGloryContext();
            foreach (var equipmentRepair in equipmentRepairs)
            {
                context.Add(equipmentRepair);
                context.SaveChanges();
            }
        }
        private IList<EquipmentRepair> EquipmentRepairs_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listEquipmentRepairs = new List<EquipmentRepair>();

            string s = sr.ReadLine();

            while (s != null)
            {
                var split = s.Split(',');
                var dateSplit = split[1].Split('/');
                var date = new DateTime(Convert.ToInt32(dateSplit[2]), Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]));

                var newEquipmentRepair = new EquipmentRepair
                {
                    EquipmentId = split[0],
                    DateOfRepair = date,
                    Amount = Convert.ToDouble(split[2]),
                    Remarks = split[3]
                };

                listEquipmentRepairs.Add(newEquipmentRepair);
                s = sr.ReadLine();
            }
            return listEquipmentRepairs;
        }
    }
}

