using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFRecursive.Entities;

namespace TestEFRecursive.DataSet
{
    public class ProfileDataSet : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasData(
                new Profile
                {
                    Id = 1,
                    FirstName = "Geoffroy",
                    LastName = "Adnet",
                    Email = "g.adnet@email.be"
                },
                new Profile
                {
                    Id = 2,
                    FirstName = "Sarah",
                    LastName = "Connor",
                    Email = "s.connor@skynet.com"
                },
                new Profile
                {
                    Id = 3,
                    FirstName = "Lucifer",
                    LastName = "Morningstar",
                    Email = "hell.master69@lux.god"
                }
            );
        }
    }
}
