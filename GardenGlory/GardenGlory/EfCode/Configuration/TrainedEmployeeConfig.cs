using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace GardenGlory.EfCode.Configuration
{
    public class TrainedEmployeeConfig :IEntityTypeConfiguration<TrainedEmployee>
    {
        public void Configure(EntityTypeBuilder<TrainedEmployee> builder)
        {
            builder.ToTable("TrainedEmployee"); // name of table

            builder.HasKey(c => c.TrainedEmployeeId); // primary key 
            builder.Property(c => c.TrainedEmployeeId).HasValueGenerator(typeof(TrainedEmployeeKeyGenerator)); // generate values

            builder.HasOne(c => c.EmployeeLink).WithMany(c => c.TrainedEmployees)
                .HasForeignKey(c => c.EmployeeId);
            builder.HasOne(c => c.EquipmentLink).WithMany(c => c.TrainedEmployees)
                .HasForeignKey(c => c.EquipmentId);
        }
    }
    public class TrainedEmployeeKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.TrainedEmployees.Count() + 1).ToString();

            key.Append("TEMP ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
