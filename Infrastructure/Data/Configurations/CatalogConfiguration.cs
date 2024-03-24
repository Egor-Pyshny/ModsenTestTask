using Infrastructure.Data.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CatalogConfiguration : IEntityTypeConfiguration<CatalogView>
    {
        public void Configure(EntityTypeBuilder<CatalogView> builder)
        {
            builder.ToView("catalogview");
            builder.Property(r => r.Id).HasColumnName("id");
            builder.Property(r => r.Name).HasColumnName("name");
            builder.Property(r => r.Time).HasColumnName("time");
            builder.Property(r => r.City).HasColumnName("city");
            builder.Property(r => r.Country).HasColumnName("country");
            builder.Property(r => r.OrganizerFirstName).HasColumnName("organizer_first_name");
            builder.Property(r => r.OrganizerSecondName).HasColumnName("organizer_second_name");
            builder.Property(r => r.Images).HasColumnName("pathes");
            builder.Property(r => r.FreePlaces).HasColumnName("free_places");
        }
    }
}
