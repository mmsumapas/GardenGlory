using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class PropertyService
    {
        private GardenGloryContext _context;
        //Get, add, update, and delete 


        public PropertyService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<Property> GetProperties()
        {
            return _context.Properties
                .Where(c=>c.IsDeleted!=true && c.OwnerLink.IsDeleted!=true && c.OwnerId!=null)
                .Include(c => c.OwnerLink)
                .Include(c => c.PropertyLink)
                .Include(c=>c.PropertyDescriptions)
                .ThenInclude(c=>c.PropertyLink);

        }

        public Property GetProperty(string propertyId)
        {
            var properties = GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyId ==propertyId)
                {
                    return property;
                }
            }

           return null;
        }

        //public bool OwnerChecker(string ownerId, string propertyId)
        //{
        //    return _context.Properties.Any(c => c.PropertyId == propertyId && c.OwnerLink.OwnerId == ownerId);
        //}
        public void AddProperty(Property property)
        {
            using (var context = new GardenGloryContext())
            {
                _context.Properties.Add(property);
                //_context.Owners.Find(owner.OwnerId).Properties.Add(property);
                _context.SaveChanges();
            }
        }

        
        public void UpdateProperty(string propertyId, string propertyName, string street,
            string city, string zip)
        {
            var property = _context.Properties.Find(propertyId);

            property.PropertyName = propertyName;
            property.Street = street;
            property.City = city;
            property.Zip = zip;
            _context.SaveChanges();
        }

        public void RemoveProperty(string propertyId)
        {
            var property = _context
                .Properties.Find(propertyId);
            property.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
