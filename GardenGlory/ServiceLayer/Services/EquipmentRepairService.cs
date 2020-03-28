using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class EquipmentRepairService
    {
        private GardenGloryContext _context;
        //Get, add and update only
        public EquipmentRepairService(GardenGloryContext context)
        {
            _context = context;
        }
        public IQueryable<EquipmentRepair> GetEquipmentRepairs()
        {
            return _context.EquipmentRepairs
                .Include(c => c.EquipmentLink);
        }
        public IQueryable<EquipmentRepair> GetEquipmentRepairs(Equipment equipment)
        {
            return _context.EquipmentRepairs
                .Where(c=>c.EquipmentId==equipment.EquipmentId)
                .Include(c => c.EquipmentLink);
        }

        public void AddEquipmentRepair(EquipmentRepair equipmentRepair)
        {
            using (var context = new GardenGloryContext())
            {
                _context.EquipmentRepairs.Add(equipmentRepair);
                _context.SaveChanges();
            }
        }

        public void UpdateEquipmentRepair(int equipmentRepairId, DateTime dateOfRepair,
            double amount, string remarks)
        {
            var equipmentRepair = _context.EquipmentRepairs.Find(equipmentRepairId);
            
            equipmentRepair.DateOfRepair = dateOfRepair;
            equipmentRepair.Amount = amount;
            equipmentRepair.Remarks = remarks;
        }
    }
}
