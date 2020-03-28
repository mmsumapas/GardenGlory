using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class AccountService
    {
        private GardenGloryContext _context;
        
        //Allow get, add, update, and delete
        public AccountService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<Account> GetAccounts() //
        {
            return _context.Accounts.Where(c => c.IsDeleted != true)
                .Include(c => c.EmployeeLink)
                .ThenInclude(c => c.EmployeeTypeLink)
                .Include(c => c.RoleLink)
                .ThenInclude(c => c.AccessRestrictionLink);

        }

        public void AddAccount(Account account)
        {
            using (var context = new GardenGloryContext())
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
            }
        }

        public void UpdateAccount(string accountId, string roleId, string username, string password)
        {
            var account = _context.Accounts.Find(accountId);

            account.RoleId = roleId;
            account.Password = password;
            account.Username = username;
            _context.SaveChanges();

            //Check if the account is deleted before using this method.
        }

        public void UpdateEmployeeBaseAccount(Employee employeeDetails)
        {
            _context.Employees.Update(employeeDetails);
            _context.SaveChanges();
        }
        public void RemoveAccount(string accountId)
        {
            var account = _context.Accounts.Find(accountId);
            account.IsDeleted = true;
            _context.SaveChanges();
        }

        public bool AccessChecker(string username, string password)
        {
            return _context.Accounts.Any(c => c.Username == username && c.Password == password);
        }
        
        

   

        
    }
}
