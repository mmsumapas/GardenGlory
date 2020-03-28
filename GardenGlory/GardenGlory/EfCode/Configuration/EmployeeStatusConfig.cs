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
    public class EmployeeStatusConfig : IEntityTypeConfiguration<EmployeeStatus>
    {
        public void Configure(EntityTypeBuilder<EmployeeStatus> builder)
        {
            builder.ToTable("EmployeeStatus"); // name of table

            builder.HasKey(c => c.EmployeeStatusId); // primary key 
            builder.Property(c => c.EmployeeStatusId).HasValueGenerator(typeof(EmployeeStatusKeyGenerator)); // generate values
        }

        public class EmployeeStatusKeyGenerator : ValueGenerator
        {
            protected override object NextValue(EntityEntry entry)
            {
                var context = new GardenGloryContext();
                var key = new StringBuilder();

                var num = (context.EmployeeStatuses.Count() + 1).ToString();

                key.Append("EMPS ");
                key.Append($"{num.PadLeft(3, '0')}");
                return key.ToString();
            }
            public override bool GeneratesTemporaryValues => false;
        }
    }
}
