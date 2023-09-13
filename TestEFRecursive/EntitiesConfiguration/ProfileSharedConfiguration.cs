using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFRecursive.Entities;

namespace TestEFRecursive.EntitiesConfiguration
{
    public class ProfileSharedConfiguration : IEntityTypeConfiguration<ProfileShared>
    {
        public void Configure(EntityTypeBuilder<ProfileShared> builder)
        {
            builder.ToTable("ProfileShared");
            
            builder.HasKey(ps => new { ps.BasedUserId, ps.SharedProfileId });

            builder.HasOne(ps => ps.profile)
                   .WithMany(p => p.ProfilesBase)
                   .HasForeignKey(fk => fk.BasedUserId);

            builder.HasOne(ps => ps.profile)
                   .WithMany(p => p.ProfilesShared)
                   .HasForeignKey(fk => fk.SharedProfileId);

        }
    }
}
