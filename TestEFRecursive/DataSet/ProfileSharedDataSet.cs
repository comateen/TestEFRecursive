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
    public class ProfileSharedDataSet : IEntityTypeConfiguration<ProfileShared>
    {
        public void Configure(EntityTypeBuilder<ProfileShared> builder)
        {
            builder.HasData(
                //new ProfileShared { BasedUserId = 1, SharedProfileId = 1 },
                new ProfileShared { BasedUserId = 3, SharedProfileId = 1 },
                new ProfileShared { BasedUserId = 1, SharedProfileId = 2 },
                //new ProfileShared { BasedUserId = 2, SharedProfileId = 2 },
                new ProfileShared { BasedUserId = 3, SharedProfileId = 2 }
            );

        }
    }
}
