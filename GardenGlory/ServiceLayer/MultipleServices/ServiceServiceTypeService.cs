using System;
using System.Collections.Generic;
using System.Text;
using GardenGlory.Context;

namespace ServiceLayer.MultipleServices
{
    public class ServiceServiceTypeService
    {
        public ServiceService ServiceService { get; }
        public ServiceTypeService ServiceTypeService { get; }

        public ServiceServiceTypeService(GardenGloryContext context)
        {
            ServiceService =new ServiceService(context);
            ServiceTypeService = new ServiceTypeService(context);
        }
    }
}
