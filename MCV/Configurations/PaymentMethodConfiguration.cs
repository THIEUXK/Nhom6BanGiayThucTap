using MCV.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCV.Configurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(c => c.id);
            builder.HasOne(c => c.Order).WithMany(c => c.PaymentMethods).HasForeignKey(c => c.Orderid);
        }
    }
}
