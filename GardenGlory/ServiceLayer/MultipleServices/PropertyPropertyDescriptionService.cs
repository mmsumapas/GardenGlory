using System;
using System.Collections.Generic;
using System.Text;
using GardenGlory.Context;

namespace ServiceLayer.MultipleServices
{
    public class PropertyPropertyDescriptionService
    {
        public PropertyService PropertyService { get; }
        public PropertyDescriptionService PropertyDescriptionService { get; }

        public PropertyPropertyDescriptionService(GardenGloryContext context)
        {
            PropertyService = new PropertyService(context);
            PropertyDescriptionService = new PropertyDescriptionService(context);
        }
    }
}
