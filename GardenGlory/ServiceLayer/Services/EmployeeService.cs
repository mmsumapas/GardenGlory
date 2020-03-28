using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class EmployeeService
    {
        private GardenGloryContext _context;

        //get, add, update, and delete
        public EmployeeService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return _context.Employees.Where(c => c.IsDeleted != true)
                .Include(c => c.EmployeeStatusLink)
                .Include(c => c.EmployeeTypeLink)
                .Include(c => c.ExperienceLevelLink)
                .Include(c => c.EmployeeLink);
        }
        public Employee GetEmployee(string employeeId)
        {
            var employees = GetEmployees();
            foreach (var employee in employees)
            {
                if (employee.EmployeeId == employeeId)
                {
                    return employee;
                }
            }

            return null;
        }
        public void AddEmployee (Employee employee)
        {
            using (var context = new GardenGloryContext())
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();

            }
        }

        public void UpdateEmployee(string employeeId, string experienceLevelId, string employeeStatusId, string supervisorId,
            string employeeTypeId, string lastName, string firstName, string cellPhone)
        {
            var employee = _context.Employees.Find(employeeId);

            employee.ExperienceLevelId = experienceLevelId;
            employee.EmployeeStatusId = employeeStatusId;
            employee.SupervisorId = supervisorId;
            employee.EmployeeTypeId = employeeTypeId;

            employee.LastName = lastName;
            employee.FirstName = firstName;
            employee.CellPhone = cellPhone;
            //Check if employee is not deleted in the system before entering this method 
            _context.SaveChanges();
        }
        public void RemoveEmployee(string employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            employee.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
