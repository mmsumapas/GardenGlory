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
    public class ServiceConfig :IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service"); // name of table

            builder.HasKey(c => c.ServiceId); // primary key 
            builder.Property(c => c.ServiceId).HasValueGenerator(typeof(ServiceKeyGenerator)); // generate values

            builder.Property(c => c.IsDeleted).HasDefaultValue(false);

            builder.HasOne(c => c.PropertyLink).WithMany(c => c.Services).HasForeignKey(c => c.PropertyId);
            builder.HasOne(c => c.ServiceTypeLink).WithMany(c => c.Services).HasForeignKey(c => c.ServiceTypeId);
        }
    }
    public class ServiceKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Services.Count() + 1).ToString();

            key.Append("SV ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
