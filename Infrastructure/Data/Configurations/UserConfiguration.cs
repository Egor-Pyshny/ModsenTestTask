using Infrastructure.Data.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDbModel>
    {
        public void Configure(EntityTypeBuilder<UserDbModel> builder)
        {
            builder.ToTable("tbl_user");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email);

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnName("password");

            builder.Property(u => u.FirstName)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("first_name");

            builder.Property(u => u.SecondName)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("second_name");

            builder.Property(u => u.ThirdName)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("third_name");

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("email");

            builder.Property(u => u.RegistrationDate)
                .IsRequired()
                .HasColumnName("registration_date");
        }
    }
}
