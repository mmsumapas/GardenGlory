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
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property");

            builder.HasKey(c => c.PropertyId);
            builder.Property(c => c.PropertyId).HasValueGenerator(typeof(PropertyKeyGenerator));

            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.Property(c => c.ParentPropertyId).IsRequired(false);

            builder.HasOne(c => c.OwnerLink).WithMany(c => c.Properties).HasForeignKey(c => c.OwnerId);
            builder.HasOne(c => c.PropertyLink).WithMany(c => c.Properties).HasForeignKey(c => c.ParentPropertyId)
                .IsRequired(false);

        }
    }
    public class PropertyKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Properties.Count() + 1).ToString();

            key.Append("PP ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
