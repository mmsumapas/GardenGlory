using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class OwnerType
    {
        public string OwnerTypeId { get; set; }
        public string Type { get; set; } //Individual or Organization (2)
        public string OwnerTypeName => $"{Type}";
        
        //Relation
        public ICollection<Owner> Owners { get; set; }
    }
}
