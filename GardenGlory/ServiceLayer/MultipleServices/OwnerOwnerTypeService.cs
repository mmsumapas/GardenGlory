using System;
using System.Collections.Generic;
using System.Text;
using GardenGlory.Context;

namespace ServiceLayer.MultipleServices
{
    public class OwnerOwnerTypeService
    {
        //public CustomerService CustomerService { get; }
        //public RegionService RegionService { get; }

        //public CustomerRegionService(GcsContext context)
        //{
        //    CustomerService = new CustomerService(context);
        //    RegionService = new RegionService(context);
        //}
        public OwnerService OwnerService { get; }
        public OwnerTypeService OwnerTypeService { get; }

        public OwnerOwnerTypeService(GardenGloryContext context)
        {
            OwnerService = new OwnerService(context);
            OwnerTypeService = new OwnerTypeService(context);
        }
	}
}
