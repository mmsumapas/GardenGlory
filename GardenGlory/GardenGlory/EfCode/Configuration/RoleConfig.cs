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
    public class RoleConfig: IEntityTypeConfiguration<Role> 
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role"); // name of table

            builder.HasKey(c => c.RoleId); // primary key 
            builder.Property(c => c.RoleId).HasValueGenerator(typeof(RoleKeyGenerator)); // generate values

            builder.HasOne(c => c.AccessRestrictionLink).WithMany(c => c.Roles).HasForeignKey(c => c.RestrictionId);
        }
    }
    public class RoleKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Roles.Count() + 1).ToString();

            key.Append("RL ");
            key.Append($"{num.PadLeft(4, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
