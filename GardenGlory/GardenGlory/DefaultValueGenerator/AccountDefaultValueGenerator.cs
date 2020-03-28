using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;

namespace GardenGlory.DefaultValueGenerator
{
    public class AccountDefaultValueGenerator
    {
        private GardenGloryContext _context;
        public AccountDefaultValueGenerator(GardenGloryContext context)
        {
            _context = context;
        }

        public string PrimaryKeyGenerator()
        {
            var key = new StringBuilder();

            var num = (_context.Accounts.Count() + 1).ToString();

            key.Append("ACC ");
            key.Append(DateTime.Now.Year.ToString());
            key.Append($" {num.PadLeft(6, '0')}");

            return key.ToString();
        }
        public string PasswordGenerator( string employeeId)
        {
            var count = _context.Accounts.Count();

            var password = $"{employeeId + " " + count}";

            return password;
        }

        public string UsernameGenerator(string employeeId)
        {
            var username = new StringBuilder();
            var count = _context.Accounts.Count();

            var employee = _context.Employees.Find(employeeId);

            var firstName = employee.FirstName;
            var lastName = employee.LastName;

            if (firstName.Contains(" "))
            {
                var split = firstName.Split(" ");
                foreach (var s in split)
                {
                    if(char.IsLetter(s[0]) == true && s!="") 
                        username.Append(s[0]);
                }
            }
            else
            {
                username.Append(firstName[0]);
            }

            if (lastName.Contains(" "))
            {
                lastName = lastName.Replace(" ", "");
                username.Append(lastName);
            }
            else
                username.Append(lastName);

            return username.ToString();

        }

    }
}
