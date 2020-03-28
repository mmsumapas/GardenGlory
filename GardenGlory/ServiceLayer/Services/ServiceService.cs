using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class ServiceService
    {
        private GardenGloryContext _context;

        //Get, add, update, and delete 
        public ServiceService(GardenGloryContext context)
        {
            _context = context;
        }
        public IQueryable<Service> GetServices()
        {
            return _context.Services.Where(c => c.IsDeleted != true && c.PropertyLink.IsDeleted!=true && c.PropertyLink.OwnerLink.IsDeleted!=true )
                .Include(c => c.ServiceTypeLink)
                .Include(c => c.PropertyLink)
                .ThenInclude(c=>c.OwnerLink);

        }
        public IQueryable<Service> GetServices(string ownerId)
        {
            return _context.Services.Where(c => c.IsDeleted != true && c.PropertyLink.IsDeleted!=true && c.PropertyLink.OwnerLink.OwnerId == ownerId)
                .Include(c => c.ServiceTypeLink)
                .Include(c => c.PropertyLink)
                .ThenInclude(c => c.OwnerLink);

        }
        public Service GetService (string serviceId)
        {
            var services = GetServices();
            foreach (var service in services)
            {
                if (service.ServiceId == serviceId)
                {
                    return service;
                }
            }

            return null;
        }

        public void AddService(Service service)
        {
            using (var context = new GardenGloryContext())
            {
                _context.Services.Add(service);
                _context.SaveChanges();
            }
        }

        public void UpdateService(string serviceId, string serviceTypeId, string serviceRequest)
        {
            var service = _context.Services.Find(serviceId);

            service.ServiceTypeId = serviceTypeId;
            service.RequestDate = service.RequestDate;
            service.ServiceRequest = serviceRequest;
            _context.SaveChanges();
        }


        public void RemoveService(string serviceId)
        {
            var service = _context.Services.Find(serviceId);
            service.IsDeleted = true;
            _context.SaveChanges();
        }

    }
}
