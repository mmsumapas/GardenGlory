using System;
using System.Linq;
using GardenGlory.Context;
using GardenGlory.EfClasses;

namespace ServiceLayer
{
    public class AccessRestrictionService
    {
        private GardenGloryContext _context;

        //get and update only 
        // fixt to 3 types of access: RIC, RICD, RICDE
        //R: Read, I: Insert, C: Change, D: Delete, E: access to Employee Supervisor
        public AccessRestrictionService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<AccessRestriction> GetAccessRestrictions()
        {
            //Walay checking if ang employee is deleted or not 
            return _context.AccessRestrictions;
        }

        public void UpdateAcessRestriction(int restrictionId, string type)
        {
            var restriction = _context.AccessRestrictions.Find(restrictionId);
            restriction.Type = type;

            _context.SaveChanges();
        }
    }
}
