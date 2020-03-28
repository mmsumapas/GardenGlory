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
    public class ExperienceLevelConfig : IEntityTypeConfiguration<ExperienceLevel>
    {
        public void Configure(EntityTypeBuilder<ExperienceLevel> builder)
        {
            builder.ToTable("ExperienceLevel"); // name of table

            builder.HasKey(c => c.ExperienceLevelId); // primary key 
            builder.Property(c => c.ExperienceLevelId).HasValueGenerator(typeof(ExperienceLevelKeyGenerator)); // generate values
        }
    }
    public class ExperienceLevelKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.ExperienceLevels.Count() + 1).ToString();

            key.Append("EL ");
            key.Append($"{num.PadLeft(3, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
