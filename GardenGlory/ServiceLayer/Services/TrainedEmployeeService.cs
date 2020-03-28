using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.MultipleServices;

namespace ServiceLayer
{
    public class TrainedEmployeeService
    {
        private GardenGloryContext _context;

        //get and add only
        public TrainedEmployeeService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<TrainedEmployee> GetTrainedEmployees()
        {
            return _context.TrainedEmployees
                .Include(c => c.EquipmentLink)
                .Include(c => c.EmployeeLink.IsDeleted != true);
        }
        public IQueryable<TrainedEmployee> GetTrainedEmployees(Equipment equipment)
        {
            return _context.TrainedEmployees
                .Where(c=>c.EquipmentId == equipment.EquipmentId && c.EmployeeLink.IsDeleted!=true && c.EquipmentLink.IsDeleted != true)
                .Include(c=>c.EquipmentLink)
                .Include(c => c.EmployeeLink);
        }

        public void AddTrainedEmployee(TrainedEmployee trainedEmployee)
        {
            using (var context = new GardenGloryContext())
            {
                _context.TrainedEmployees.Add(trainedEmployee);
                _context.SaveChanges();
            }
        }
    }
}
