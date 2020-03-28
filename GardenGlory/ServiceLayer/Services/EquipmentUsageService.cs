using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class EquipmentUsageService
    {
        private GardenGloryContext _context;
        //Get, add, and update only
        public EquipmentUsageService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<EquipmentUsage> GetquipmentUsages()
        {
            return _context.EquipmentUsages.
                Include(c => c.EquipmentLink)
                .Include(c=>c.TaskLink);
        }


        public IQueryable<EquipmentUsage> GetEquipmentUsages(Equipment equipment)
        {
            return _context.EquipmentUsages
                .Where(c=>c.EquipmentId == equipment.EquipmentId)
                .Include(c => c.EquipmentLink)  
                .Include(c => c.TaskLink);
        }
        public void AddEquipmentUsage(EquipmentUsage equipmentUsage)
        {
            using (var context = new GardenGloryContext())
            {
                _context.EquipmentUsages.Add(equipmentUsage);
                _context.SaveChanges();
            }
        }
        public void UpdateEquipmentUsage(int equipmentUsageId, string usageDescription)
        {
            var equipmentUsage = _context.EquipmentUsages.Find(equipmentUsageId);

            equipmentUsage.UsageDescription = usageDescription;
            _context.SaveChanges();
        }
    }
}
