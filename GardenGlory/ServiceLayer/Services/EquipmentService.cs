using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class EquipmentService
    {
        private GardenGloryContext _context;
        // Get, add, edit, and remove 
        public EquipmentService(GardenGloryContext context)
        {
            _context = context;
        }
        public IQueryable<Equipment> GetEquipments()
        {
            return _context.Equipments.Where(c => c.IsDeleted != true)
                .Include(c => c.TrainedEmployees);

        }
        public Equipment GetEquipment(string equipmentId)
        {
            var equipments = GetEquipments();
            foreach (var equipment in equipments)
            {
                if (equipment.EquipmentId == equipmentId)
                {
                    return equipment;   
                }
            }

            return null;
        }

        public bool IsTrained(Equipment equipment, string employeeId)
        {
            foreach (var trainedEmployee in equipment.TrainedEmployees)
            {
                if (trainedEmployee.EmployeeId == employeeId)
                {
                    return true;
                }
            }

            return false;
        }
        public void AddEquipment(Equipment equipment)
        {
            using (var context = new GardenGloryContext())
            {
                _context.Equipments.Add(equipment);
                _context.SaveChanges();
            }
        }
        public void UpdateEquipment(string equipmentId, string equipmentName)
        {
            var equipment = _context.Equipments.Find(equipmentId);
            equipment.EquipmentName = equipmentName;
            _context.SaveChanges();

        }

        public void RemoveEquipment(string equipmentId)
        {
            var equipment = _context.Equipments.Find(equipmentId);
            equipment.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
