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
    public class AccessRestrictionConfig :IEntityTypeConfiguration<AccessRestriction>
    {
        public void Configure(EntityTypeBuilder<AccessRestriction> builder)
        {
            builder.ToTable("AccessRestriction"); // name of table

            builder.HasKey(c => c.RestrictionId); // primary key 
            builder.Property(c => c.RestrictionId).HasValueGenerator(typeof(AccessRestrictionKeyGenerator)); // generate values
        }
    }
    public class AccessRestrictionKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.AccessRestrictions.Count() + 1).ToString();
            key.Append("ACR ");
            key.Append($"{num.PadLeft(3, '0')}");
            return key.ToString();
        }

        public override bool GeneratesTemporaryValues => false;
    }

}
