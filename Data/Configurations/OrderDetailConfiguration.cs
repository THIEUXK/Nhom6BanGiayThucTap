using MCV.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCV.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(c => c.id);

            builder.HasOne(c => c.Order).WithMany(c => c.Details).HasForeignKey(c => c.OrderId);
            builder.HasOne(c => c.ShoeDetail).WithMany(c => c.OrderDetails).HasForeignKey(c => c.ShoeDetailId);

        }
    
    }
}
