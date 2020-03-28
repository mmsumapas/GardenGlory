using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class AccessRestriction
    {
        public string RestrictionId { get; set; }
        
        public string Type { get; set; }
        
        //Relation 
       // public ICollection<RoleRestriction> RoleRestrictions { get; set; }
       public ICollection<Role> Roles { get; set; }
    }
}
 