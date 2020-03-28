using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using GardenGlory.Context;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Home
{
    public class HomeViewModel
    {
        private GardenGloryContext _context;
        private AccountService _accountService;
        private TextBlock _user;
        private TextBlock _userRole;
        public HomeViewModel(GardenGloryContext context, AccountService accountService, string username,  string password,TextBlock user, TextBlock userRole)
        {
            _context = context;
            _accountService = accountService;
            _user = user;
            _userRole = userRole;

            RestrictionChecker(username, password);
        }

        public void RestrictionChecker(string username, string password)
        {
            var accountAccess = _accountService.AccessChecker(username, password);
           
            if (accountAccess == true)
            {
                var accounts = _accountService.GetAccounts();
                foreach (var account in accounts)
                {
                    if (account.Username == username && account.Password == password)
                    {
                        RestrictionType = account.RoleLink.AccessRestrictionLink.Type;
                        _user.Text= account.EmployeeLink.EmployeeFullName;
                        _userRole.Text = account.RoleLink.RoleType;
                        Account = account;

                    }
                }
            }
            else
            {
               RestrictionType = "Error";
            }
        }
        public string RestrictionType { get; set; }
        public GardenGlory.EfClasses.Account Account { get; set; }

    }
}
