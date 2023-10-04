using MCV.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MCV.Configurations
{
    public class ShoeConfiguration : IEntityTypeConfiguration<Shoe>
    {
        public void Configure(EntityTypeBuilder<Shoe> builder)
        {
            builder.HasKey(c => c.id);
        }
    }
}
