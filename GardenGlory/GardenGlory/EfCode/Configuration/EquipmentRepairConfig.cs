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
    public class EquipmentRepairConfig: IEntityTypeConfiguration<EquipmentRepair>
    {
        public void Configure(EntityTypeBuilder<EquipmentRepair> builder)
        {
            builder.ToTable("EquipmentRepair"); // name of table

            builder.HasKey(c => c.EquipmentRepairId); // primary key 
            builder.Property(c => c.EquipmentRepairId).HasValueGenerator(typeof(EquipmentRepairKeyGenerator)); // generate values

            builder.HasOne(c => c.EquipmentLink).WithMany(c => c.EquipmentRepairs)
                .HasForeignKey(c => c.EquipmentId).IsRequired(false);
        }
    }
    public class EquipmentRepairKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.EquipmentRepairs.Count() + 1).ToString();

            key.Append("EQR ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
