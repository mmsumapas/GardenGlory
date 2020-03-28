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
   public class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.HasKey(c => c.OwnerId);
            builder.Property(c => c.OwnerId).HasValueGenerator(typeof(OwnerKeyGenerator));

            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.HasOne(c => c.OwnerTypeLink).WithMany(c => c.Owners).HasForeignKey(c => c.OwnerTypeId);


        }
    }
   public class OwnerKeyGenerator : ValueGenerator
   {
       protected override object NextValue(EntityEntry entry)
       {
           var context = new GardenGloryContext();
           var key = new StringBuilder();

           var num = (context.Owners.Count() + 1).ToString();

           key.Append("ON ");
           key.Append($"{num.PadLeft(6, '0')}");
           return key.ToString();
       }
       public override bool GeneratesTemporaryValues => false;
   }
}
