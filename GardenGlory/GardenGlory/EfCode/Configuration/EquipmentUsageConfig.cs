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
    public class EquipmentUsageConfig : IEntityTypeConfiguration<EquipmentUsage>
    {
        public void Configure(EntityTypeBuilder<EquipmentUsage> builder)
        {
            builder.ToTable("EquipmentUsage"); // name of table

            builder.HasKey(c => c.EquipmentUsageId); // primary key 
            builder.Property(c => c.EquipmentUsageId).HasValueGenerator(typeof(EquipmentUsageKeyGenerator)); // generate values

            builder.HasOne(c => c.TaskLink).WithMany(c => c.EquipmentUsages).HasForeignKey(c => c.TaskId);
            builder.HasOne(c => c.EquipmentLink).WithMany(c => c.EquipmentUsages).HasForeignKey(c => c.EquipmentId);
        }
    }
    public class EquipmentUsageKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.EquipmentUsages.Count() + 1).ToString();

            key.Append("EQU ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
