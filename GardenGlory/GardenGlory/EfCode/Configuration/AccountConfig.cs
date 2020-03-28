using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace GardenGlory.EfCode.Configuration
{
    public class AccountConfig: IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account"); // name of table

            builder.HasKey(c => c.AccountId); // primary key 

            builder.Property(c => c.AccountId).HasValueGenerator(typeof(AccountKeyGenerator)); // generate values
            builder.Property(c => c.EmployeeId).HasValueGenerator(typeof(EmployeeIdGenerator)); // generate values
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.Property(c => c.Username).HasValueGenerator(typeof(UsernameGenerator)); // generate values
            builder.Property(c => c.Password).HasValueGenerator(typeof(PasswordGenerator)); // generate values

            builder.HasOne(c => c.EmployeeLink).WithMany(c => c.Accounts).HasForeignKey(c => c.EmployeeId);
            builder.HasOne(c => c.RoleLink).WithMany(c => c.Accounts).HasForeignKey(c => c.RoleId);
        }
    }

    public class AccountKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Accounts.Count() + 1).ToString();

            key.Append("ACC ");
            key.Append(DateTime.Now.Year.ToString());
            key.Append($" {num.PadLeft(6,'0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }

    public class UsernameGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var username = new StringBuilder();
            var count = context.Accounts.Count();

            var employees = context.Employees.Where(c => (c.EmployeeTypeId == "EMPT 008") || (c.EmployeeTypeId == "EMPT 012") || (c.EmployeeTypeId == "EMPT 013")).ToList();


            var employee = employees[count];

            var firstName = employee.FirstName;
            var lastName = employee.LastName;
            
            if (firstName.Contains(" "))
            {
                var split = firstName.Split(" ");
                foreach (var s in split)
                {
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
        public override bool GeneratesTemporaryValues => false;
    }

    public class PasswordGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var count = context.Accounts.Count();

            var employees = context.Employees.Where(c => (c.EmployeeTypeId == "EMPT 008") || (c.EmployeeTypeId == "EMPT 012") || (c.EmployeeTypeId == "EMPT 013")).ToList();


            var employee = employees[count];

            var password = $"{employee.EmployeeId + " " + count}";

            return password;
        }
        public override bool GeneratesTemporaryValues => false;
    }
    public class EmployeeIdGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var username = new StringBuilder();
            var count = context.Accounts.Count();

            var employees = context.Employees.Where(c => (c.EmployeeTypeId == "EMPT 008") || (c.EmployeeTypeId == "EMPT 012") || (c.EmployeeTypeId == "EMPT 013")).ToList();

            var employee = employees[count];

            var employeeId = employee.EmployeeId;

            return employeeId;
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
