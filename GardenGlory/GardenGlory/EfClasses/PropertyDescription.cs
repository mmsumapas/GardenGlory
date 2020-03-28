using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class PropertyDescription
    {
        public string PropertyDescriptionId { get; set; }
        public string PropertyId { get; set; }
        public  string Description { get; set; }
        public bool IsDeleted { get; set; }

        //Relation 
        public Property PropertyLink { get; set; }
    }
}
