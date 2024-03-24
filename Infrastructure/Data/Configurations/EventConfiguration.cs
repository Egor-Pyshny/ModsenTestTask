using Infrastructure.Data.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<EventDbModel>
    {
        public void Configure(EntityTypeBuilder<EventDbModel> builder)
        {
            builder.ToTable("tbl_event");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .HasColumnName("id");

            builder.Property(e => e.Name)
               .HasMaxLength(50)
               .IsRequired()
               .HasColumnName("name");

            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.Property(e => e.Description)
                .HasMaxLength(4000)
                .IsRequired()
                .HasColumnName("description");

            builder.Property(e => e.Plan)
                .HasMaxLength(2000)
                .IsRequired()
                .HasColumnName("plan");

            builder.Property(e => e.OrganizerFirstName)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("organizer_first_name");

            builder.Property(e => e.OrganizerSecondName)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("organizer_second_name");

            builder.Property(e => e.SpickerFirstName)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("spicker_first_name");

            builder.Property(e => e.SpickerSecondName)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("spicker_second_name");

            builder.Property(e => e.Country)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("country");

            builder.Property(e => e.City)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("city");

            builder.Property(e => e.Street)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("street");

            builder.Property(e => e.Category)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("category");

            builder.Property(e => e.Time)
                .IsRequired()
                .HasColumnName("time");

            builder.Property(e => e.MaxParticipants)
                .IsRequired()
                .HasColumnName("max_participants");

            builder.Property(e => e.FreePlaces)
                .IsRequired()
                .HasColumnName("free_places");
        }
    }
}
