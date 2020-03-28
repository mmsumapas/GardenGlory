using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class OwnerService
    {
        private GardenGloryContext _context;
        //Get, add, update, and delete

        public OwnerService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<Owner> GetOwners()
        {
            return _context.Owners.Where(c => c.IsDeleted != true)
                .Include(c => c.OwnerTypeLink);
        }

        public IQueryable<Property> GetProperties(string ownerId)
        {
            return _context.Properties.Where(c => c.OwnerId == ownerId && c.IsDeleted != true)
                .Include(c=>c.OwnerLink);
        }
        public Owner GetOwner(string ownerId)
        {
            var owners = GetOwners();
            foreach (var owner in owners)
            {
                if (owner.OwnerId == ownerId)
                {
                    return owner;
                }
            }

            return null;
        }
       


        //public IQueryable<Employee> GetEmployees(int regionId)
        //{
        //    return _context.Employees
        //        .Where(c => c.RegionId == regionId)
        //        .Include(c => c.RegionLink);
        //}

        public void AddOwner(Owner owner)
        {
            using (var context = new GardenGloryContext())
            {
                _context.Owners.Add(owner);
                _context.SaveChanges();
            }
        }

        public void UpdateOwner(string ownerId, string ownerTypeId, string ownerName,
            string ownerEmail, string contactNumber)
        {
            var owner = _context.Owners.Find(ownerId);
            owner.OwnerTypeId = ownerTypeId;
            owner.OwnerName = ownerName;
            owner.OwnerEmail = ownerEmail;
            owner.ContactNumber = contactNumber;
            _context.SaveChanges();
        }

        public void RemoveOwner(string ownerId)
        {
            var owner = _context.Owners.Find(ownerId);
            owner.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
