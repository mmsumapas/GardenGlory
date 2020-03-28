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
   public class PropertyDescriptionConfig : IEntityTypeConfiguration<PropertyDescription>
    {
        public void Configure(EntityTypeBuilder<PropertyDescription> builder)
        {
            builder.ToTable("PropertyDescription"); // name of table

            builder.HasKey(c => c.PropertyDescriptionId); // primary key 
            builder.Property(c => c.PropertyDescriptionId).HasValueGenerator(typeof(PropertyDescriptionKeyGenerator)); // generate values

            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.HasOne(c => c.PropertyLink).WithMany(c => c.PropertyDescriptions)
                .HasForeignKey(C => C.PropertyId).IsRequired(false);


        }
    }
   public class PropertyDescriptionKeyGenerator : ValueGenerator
   {
       protected override object NextValue(EntityEntry entry)
       {
           var context = new GardenGloryContext();
           var key = new StringBuilder();

           var num = (context.PropertyDescriptions.Count() + 1).ToString();

           key.Append("PPD ");
           key.Append($"{num.PadLeft(6, '0')}");
           return key.ToString();
       }
       public override bool GeneratesTemporaryValues => false;
   }
}
