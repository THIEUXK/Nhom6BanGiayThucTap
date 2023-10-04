using MCV.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCV.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(c => c.id);
            builder.HasOne(c => c.ShoeDetail).WithMany(c => c.Images).HasForeignKey(c => c.ShoeDetailId);
        }
    }
}
