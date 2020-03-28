using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;

namespace ServiceLayer
{
    public class RoleService
    {
        private GardenGloryContext _context;
        public RoleService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<Role> GetRoles()
        {
            return _context.Roles;
        }

        public void UpdateOwnerType(int roleId, string role)
        {
            var updateRole= _context.Roles.Find(roleId);

            updateRole.RoleType= role;
            _context.SaveChanges();
        }
    }
}
