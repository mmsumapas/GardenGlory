using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{
    public class EmployeeDataGenerate
    {
        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var employees =
                Employees_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\Employee\Employee5.CSV");

            using var context = new GardenGloryContext();
            foreach (var employee in employees)
            {
                context.Add(employee);
                context.SaveChanges();
            }
        }

        private IList<Employee> Employees_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listEmplyees = new List<Employee>();

            string s = sr.ReadLine();
            
            while (s != null)
            {
                var split = s.Split(',');
                if (split.Length == 6)
                {
                    var newEmployee = new Employee
                    {
                        ExperienceLevelId = split[0],
                        EmployeeStatusId = split[1],
                        EmployeeTypeId = split[2],
                        LastName = split[3],
                        FirstName = split[4],
                        CellPhone = split[5],
                    };
                    listEmplyees.Add(newEmployee);

                }
                else
                {
                    var newEmployee = new Employee
                    {
                        ExperienceLevelId = split[0],
                        EmployeeStatusId = split[1],
                        SupervisorId = split[2],
                        EmployeeTypeId = split[3],
                        LastName = split[4],
                        FirstName = split[5],
                        CellPhone = split[6],
                    };

                    listEmplyees.Add(newEmployee);
                }
                
                s = sr.ReadLine();
            }
            return listEmplyees;
        }
    }
}

