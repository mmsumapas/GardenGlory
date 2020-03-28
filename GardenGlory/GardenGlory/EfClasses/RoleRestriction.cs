using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class RoleRestriction
    {
        public string RRestrictionId { get; set; }
        public string RoleId { get; set; }
        public string RestrcitionId { get; set; }

        //Relation 
        public Role RoleLink { get; set; }
        public AccessRestriction AccessRestrictionLink { get; set; }
    }
}
