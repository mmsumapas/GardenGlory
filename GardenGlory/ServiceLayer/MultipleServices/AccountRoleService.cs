using System;
using System.Collections.Generic;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;

namespace ServiceLayer.MultipleServices
{
    public class AccountRoleService
    {
        public AccountService AccountService { get; }
        public RoleService RoleService { get; }

        public AccountRoleService(GardenGloryContext context)
        {
            AccountService = new AccountService(context);
            RoleService= new RoleService(context);
        }
    }
}
