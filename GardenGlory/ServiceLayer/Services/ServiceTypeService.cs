using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;

namespace ServiceLayer
{
    public class ServiceTypeService
    {
        private GardenGloryContext _context;

        public ServiceTypeService(GardenGloryContext context)
        {
            _context = context;
        }

        //Get, and update 
        //Fix lng ug dulo ka type: Maintenance, on-time or on-going

        public IQueryable<ServiceType> GetServiceTypes()
        {
            return _context.ServiceTypes;
        }

        public void UpdateServiceType(int serviceTypeId, string type)
        {
            var serviceType = _context.ServiceTypes.Find(serviceTypeId);
            serviceType.Type = type;
            _context.SaveChanges();
        }
    }
}
