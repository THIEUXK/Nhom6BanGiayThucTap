using MCV.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCV.Configurations
{
    public class ShoeDetailConfiguration : IEntityTypeConfiguration<ShoeDetail>
    {
        public void Configure(EntityTypeBuilder<ShoeDetail> builder)
        {
            builder.HasKey(c => c.id);
            builder.HasOne(c => c.Shoe).WithMany(c => c.ShoeDetails).HasForeignKey(c => c.ShoeId);
            builder.HasOne(c => c.Size).WithMany(c => c.ShoeDetails).HasForeignKey(c => c.SizeId);
            builder.HasOne(c => c.Category).WithMany(c => c.ShoeDetails).HasForeignKey(c => c.CategoryId);
            builder.HasOne(c => c.Brand).WithMany(c => c.ShoeDetails).HasForeignKey(c => c.BrandId);
            builder.HasOne(c => c.Color).WithMany(c => c.ShoeDetails).HasForeignKey(c => c.ColorId);
        }
    
    }
}
