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
    public class EmployeeConfig: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee"); // name of table

            builder.HasKey(c => c.EmployeeId); // primary key 
            builder.Property(c => c.EmployeeId).HasValueGenerator(typeof(EmployeeKeyGenerator)); // generate values

            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.Property(c => c.TotalHourrsWorked).HasDefaultValue("0");

            builder.HasOne(c => c.EmployeeStatusLink).WithMany(c => c.Employees).HasForeignKey(c => c.EmployeeStatusId);
            builder.HasOne(c => c.EmployeeTypeLink).WithMany(c => c.Employees).HasForeignKey(c => c.EmployeeTypeId);
            builder.HasOne(c => c.ExperienceLevelLink).WithMany(c => c.Employees).HasForeignKey(c => c.ExperienceLevelId);
            builder.HasOne(c => c.EmployeeLink).WithMany(c => c.Employees).HasForeignKey(c => c.SupervisorId).IsRequired(false);
        }

        public class EmployeeKeyGenerator : ValueGenerator
        {
            protected override object NextValue(EntityEntry entry)
            {
                var context = new GardenGloryContext();
                var key = new StringBuilder();

                var num = (context.Employees.Count() + 1).ToString();

                key.Append("EMP ");
                key.Append(DateTime.Now.Year.ToString());
                key.Append($" {num.PadLeft(6, '0')}");
                return key.ToString();
            }
            public override bool GeneratesTemporaryValues => false;
        }
    }
}
