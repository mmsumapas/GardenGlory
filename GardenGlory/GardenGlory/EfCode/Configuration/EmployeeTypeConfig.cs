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
    public class EmployeeTypeConfig : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder.ToTable("EmployeeType"); // name of table

            builder.HasKey(c => c.EmployeeTypeId); // primary key 
            builder.Property(c => c.EmployeeTypeId).HasValueGenerator(typeof(EmployeeTypeKeyGenerator)); // generate values
        }
    }
    public class EmployeeTypeKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.EmployeeTypes.Count() + 1).ToString();

            key.Append("EMPT ");
            key.Append($"{num.PadLeft(3, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
