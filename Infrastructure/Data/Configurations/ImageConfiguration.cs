using Infrastructure.Data.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<ImageDbModel>
    {
        public void Configure(EntityTypeBuilder<ImageDbModel> builder)
        {
            builder.ToTable("tbl_images");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .HasColumnName("id");

            builder.Property(e => e.Path)
               .HasMaxLength(150)
               .IsRequired()
               .HasColumnName("path");

            builder.Property(e => e.EventId)
               .IsRequired()
               .HasColumnName("event_id");
        }
    }
}
