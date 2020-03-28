using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class Role
    {
        public string RoleId { get; set; }
        public string RoleType { get; set; }
        
        public string RestrictionId { get; set; }
        public string RoleTypeName => $"{RoleType}";

        //Relation 
        public ICollection<Account> Accounts { get; set; }

        public AccessRestriction AccessRestrictionLink { get; set; }
       // public ICollection<RoleRestriction> RoleRestrictions { get; set; }
    }
}
