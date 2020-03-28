using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{ public class Owner
    {
        public string OwnerId { get; set; }
        public string OwnerTypeId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string ContactNumber { get; set; }
        public bool IsDeleted { get; set; }
        public string OwnerNameString => $"{OwnerName}";

        //Relation
        public OwnerType OwnerTypeLink { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
