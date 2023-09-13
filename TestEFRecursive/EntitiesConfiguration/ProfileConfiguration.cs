using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestEFRecursive.Entities;

namespace TestEFRecursive.EntitiesConfiguration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");

            builder.HasKey("Id");

            builder.Property(nameof(Profile.Id))
                   .ValueGeneratedOnAdd();

            builder.Property(nameof(Profile.LastName))
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(nameof(Profile.FirstName))
                   .IsRequired()
                   .HasMaxLength(50);


            builder.Property(nameof(Profile.Email))
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasCheckConstraint("CK_Email", "Email LIKE '__%@__%.%'")
                   .HasIndex(c => c.Email)
                   .IsUnique();
        }
    }
}
