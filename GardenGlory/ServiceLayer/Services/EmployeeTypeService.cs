using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class EmployeeTypeService
    {
        private GardenGloryContext _context;
        //get, add and update only 
        //Position of the employee in the garden glory 
        public EmployeeTypeService(GardenGloryContext context)
        {
            _context = context; 
        }

        public IQueryable<EmployeeType> GetEmployeeTypes()
        {
            return _context.EmployeeTypes;
        }
        public IQueryable<EmployeeType> GetEmployeeTypesWithRestriction(string restriction)
        {
            if (restriction != "ALL")
            {
                return _context.EmployeeTypes.Where(c =>
                    c.Type != "Manager" || c.Type != "Assistant" || c.Type != "Administrator");

            }
            else
            {
               return _context.EmployeeTypes;
            }
          
        }


    }
}
