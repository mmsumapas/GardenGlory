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
    public class ServiceTypeConfig: IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.ToTable("ServiceType"); // name of table

            builder.HasKey(c => c.ServiceTypeId); // primary key 
            builder.Property(c => c.ServiceTypeId).HasValueGenerator(typeof(ServiceTypeKeyGenerator)); // generate values
        }
    }
    public class ServiceTypeKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.ServiceTypes.Count() + 1).ToString();

            key.Append("SVT ");
            key.Append($"{num.PadLeft(3, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
