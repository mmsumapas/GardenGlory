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
   public class EquipmentConfig : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment"); // name of table

            builder.HasKey(c => c.EquipmentId); // primary key 
            builder.Property(c => c.EquipmentId).HasValueGenerator(typeof(EquipmentKeyGenerator)); // generate values

            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        }
    }
   public class EquipmentKeyGenerator : ValueGenerator
   {
       protected override object NextValue(EntityEntry entry)
       {
           var context = new GardenGloryContext();
           var key = new StringBuilder();

           var num = (context.Equipments.Count() + 1).ToString();

           key.Append("EQ ");
           key.Append($"{num.PadLeft(6, '0')}");
           return key.ToString();
       }
       public override bool GeneratesTemporaryValues => false;
   }

}
