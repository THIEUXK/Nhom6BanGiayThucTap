using MCV.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCV.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.id);
            builder.HasOne(c => c.Account).WithMany(c => c.Order).HasForeignKey(c => c.AccountId);
            builder.HasOne(c => c.Addresss).WithMany(c => c.Orders).HasForeignKey(c => c.AccouAddressId);
            builder.HasOne(c => c.PaymentMethod).WithMany(c => c.Orders).HasForeignKey(c => c.PaymentMethodId);

        }

    }
}
