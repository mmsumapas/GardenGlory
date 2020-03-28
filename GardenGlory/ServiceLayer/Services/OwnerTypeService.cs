using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class OwnerTypeService
    {
        private GardenGloryContext _context;

        //Get, add and update only 
        //Fix to two types only : individual or organization

        public OwnerTypeService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<OwnerType> GetOwnerTypes()
        {
            return _context.OwnerTypes;
        }
        
        public void UpdateOwnerType(int ownerTypeId, string type)
        {
            var ownerType = _context.OwnerTypes.Find(ownerTypeId);

            ownerType.Type = type;
            _context.SaveChanges();
        }
    }
}
