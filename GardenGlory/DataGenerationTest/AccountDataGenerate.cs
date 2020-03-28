using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using NUnit.Framework;

namespace DataGenerationTest
{
    public class AccountDataGenerate
    {
        [Test]
        public void GenerateCandidate_LoadCandidateDAta()
        {
            var accounts =
                Accounts_ReadFromCSV(@"C:\Users\Mecca\Documents\GitHub\GardenGlory\GardenGlory\DataFile\Account\Account(Assistant).CSV");

            using var context = new GardenGloryContext();
            foreach (var account in accounts)
            { 
                context.Add(account);
                context.SaveChanges();
            }
        }

        private IList<Account> Accounts_ReadFromCSV(string location)
        {
            var sr = new StreamReader(location);

            var listAccounts = new List<Account>();

            string s = sr.ReadLine();

            while (s != null)
            {
                var split = s.Split(',');

                var newAccount = new Account
                {
                    RoleId = split[0]
                    
                };

                listAccounts.Add(newAccount);
                s = sr.ReadLine();
            }
            return listAccounts;
        }
    }
}
