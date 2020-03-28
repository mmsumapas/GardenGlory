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
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment"); // name of table

            builder.HasKey(c => c.PaymentId); // primary key 
            builder.Property(c => c.PaymentId).HasValueGenerator(typeof(PaymentKeyGenerator)); // generate values

            builder.HasOne(c => c.ServiceLink).WithMany(C => C.Payments).HasForeignKey(C => C.ServiceId);
            builder.HasOne(c => c.PaymentMethodLink).WithMany(C => C.Payments).HasForeignKey(C => C.PaymentMethodId);
        }
    }
    public class PaymentKeyGenerator : ValueGenerator
    {
        protected override object NextValue(EntityEntry entry)
        {
            var context = new GardenGloryContext();
            var key = new StringBuilder();

            var num = (context.Payments.Count() + 1).ToString();

            key.Append("PY ");
            key.Append($"{num.PadLeft(6, '0')}");
            return key.ToString();
        }
        public override bool GeneratesTemporaryValues => false;
    }
}
