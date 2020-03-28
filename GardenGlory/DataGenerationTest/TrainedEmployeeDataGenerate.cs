using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GardenGlory;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{
    public class TrainedEmployeeDataGenerate
    {
        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var trainedEmployees =
                TrainedEmployees_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\TrainedEmployee\TrainedEmployee.CSV");

            using var context = new GardenGloryContext();
            foreach (var trainedEmployee in trainedEmployees)
            {
                context.Add(trainedEmployee);
                context.SaveChanges();
            }
        }

        private IList<TrainedEmployee> TrainedEmployees_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listTrainedEmployees = new List<TrainedEmployee>();

            string s = sr.ReadLine();

            while (s != null)
            {
                var split = s.Split(',');
                var newTrainedEmployee = new TrainedEmployee
                {
                    EmployeeId = split[0],
                    EquipmentId = split[1],
                };

                listTrainedEmployees.Add(newTrainedEmployee);
                s = sr.ReadLine();
            }
            return listTrainedEmployees;
        }
    }
}

