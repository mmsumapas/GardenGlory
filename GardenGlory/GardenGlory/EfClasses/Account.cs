using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class Account
    {
        public string AccountId { get; set; }
        public string EmployeeId { get; set; }
        public string RoleId { get; set; }
        public bool IsDeleted { get; set; }
        public string Username { get; set; }
        public  string Password { get; set; }
        

        //Relation 
        public Employee EmployeeLink { get; set; }
        public Role RoleLink { get; set; }

    }
}
