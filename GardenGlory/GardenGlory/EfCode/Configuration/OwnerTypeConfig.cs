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
    public class OwnerTypeConfig : IEntityTypeConfiguration<OwnerType>
    {
        public void Configure(EntityTypeBuilder<OwnerType> builder)
        {
            builder.ToTable("OwnerType"); // name of table

            builder.HasKey(c => c.OwnerTypeId); // primary key 
            builder.Property(c => c.OwnerTypeId).HasValueGenerator(typeof(OwnerTypeKeyGenerator)); // generate values

        }
    }

    public class OwnerTypeKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.OwnerTypes.Count() + 1).ToString();

            key.Append("ONT ");
            key.Append($"{num.PadLeft(3, '0')}");
            return key.ToString();
        }

        public override bool GeneratesTemporaryValues => false;
    }

}
