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
    public class TaskConfig :IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task"); // name of table

            builder.HasKey(c => c.TaskId); // primary key 
            builder.Property(c => c.TaskId).HasValueGenerator(typeof(TaskKeyGenerator)); // generate values

            builder.HasOne(c => c.EmployeeLink).WithMany(c => c.Tasks).HasForeignKey(c => c.EmployeeId);
            builder.HasOne(c => c.ServiceLink).WithMany(c => c.Tasks).HasForeignKey(c => c.ServiceId);
        }
    }
    public class TaskKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Tasks.Count() + 1).ToString();

            key.Append("TK ");
            key.Append($"{num.PadLeft(3, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
