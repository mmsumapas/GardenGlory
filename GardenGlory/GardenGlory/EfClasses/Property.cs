using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class Property
    {
        public string PropertyId { get; set; }
        public string  ParentPropertyId { get; set; }
        public string OwnerId { get; set; }
        public string PropertyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public bool IsDeleted { get; set; }
        public string PropertyNameString => $"{PropertyName}";

        //Relation 
        public Owner OwnerLink { get; set; }
        public  Property PropertyLink { get; set; }
        public  ICollection<Property> Properties { get; set; }
        public ICollection<PropertyDescription> PropertyDescriptions { get; set; }
        public  ICollection<Service> Services { get; set; }
    }
}
