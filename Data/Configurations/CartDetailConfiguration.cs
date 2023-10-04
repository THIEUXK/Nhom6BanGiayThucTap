using MCV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCV.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(c => c.id);
            builder.HasOne(c => c.Cart).WithMany(c => c.Details).HasForeignKey(c => c.CartId);
            builder.HasOne(c => c.ShoeDetail).WithMany(c => c.Carts).HasForeignKey(c => c.CartId);
        }
    }
}
