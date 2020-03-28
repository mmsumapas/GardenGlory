using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class PropertyDescriptionService
    {
        private GardenGloryContext _context;

        //Get, add, update, remove
        public PropertyDescriptionService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<PropertyDescription> GetDescriptions()
        {
            return _context.PropertyDescriptions
                .Where(c => c.IsDeleted != true)
                .Include(c => c.PropertyLink);
        }

        public PropertyDescription GetPropertyDescription(string propertyDescriptionId)
        {
            var propertyDescriptions = GetDescriptions();
            foreach (var propertyDescription in propertyDescriptions)
            {
                if (propertyDescription.PropertyDescriptionId == propertyDescriptionId)
                {
                    return propertyDescription;
                }
            }

            return null;
        }

        public IQueryable<PropertyDescription> GetDescriptions(string propertyId)
        {
            return _context.PropertyDescriptions
                .Where(c => c.IsDeleted != true && c.PropertyId == propertyId)
                .Include(c => c.PropertyLink);
        }
        public void AddPropertyDescription(PropertyDescription propertyDescription)
        {
            using (var context = new GardenGloryContext())
            {
                _context.PropertyDescriptions.Add(propertyDescription);
                _context.SaveChanges();
            }
        }

        public void UpdatePropertyDescription(string propertyDescriptionId, string description)
        {
            var propertyDescription = _context.PropertyDescriptions.Find(propertyDescriptionId);
            propertyDescription.Description = description;
            _context.SaveChanges();
        }

        public void RemovePropertyDescription(string propertyDescriptionId)
        {
            var propertyDescription = _context.PropertyDescriptions.Find(propertyDescriptionId);
            propertyDescription.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
