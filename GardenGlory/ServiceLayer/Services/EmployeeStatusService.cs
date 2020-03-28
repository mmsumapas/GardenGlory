using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;

namespace ServiceLayer
{
    public class EmployeeStatusService
    {
        private GardenGloryContext _context;

        // get, and update only 
        // fix to full time or part time
        public EmployeeStatusService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<EmployeeStatus> GetEmployeeStatuses()
        {
            return _context.EmployeeStatuses;
        }

        public void UpdateEmployeeStatus(int employeeStatusId, string status)
        {
            var employeeStatus = _context.EmployeeStatuses.Find(employeeStatusId);
            employeeStatus.Status = status;
            _context.SaveChanges();

            //Check if the employee is deleted or not 
        }
    }
}
