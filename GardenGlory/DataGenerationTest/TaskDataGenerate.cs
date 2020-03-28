using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{
    public class TaskDataGenerate
    {
        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var tasks =
                Tasks_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\Task\Task.CSV");

            using var context = new GardenGloryContext();
            foreach (var task in tasks)
            {
                context.Add(task);
                context.SaveChanges();
            }
        }

        private IList<Task> Tasks_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listTasks = new List<Task>();

            string s = sr.ReadLine();

            while (s != null)
            {
                var split = s.Split(',');

                var dateSplit = split[2].Split('/');
                var date = new DateTime(Convert.ToInt32(dateSplit[2]), Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]));
                var newTask = new Task
                {
                    EmployeeId = split[0],
                    ServiceId = split[1],
                    DateConducted = date,
                    HoursWorked = Convert.ToDouble(split[3]),
                    TaskName = split[4]
                };

                listTasks.Add(newTask);
                s = sr.ReadLine();
            }
            return listTasks;
        }
    }
}

