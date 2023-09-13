using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFRecursive.Entities
{
    public class ProfileShared
    {
        public int BasedUserId { get; set; }
        public virtual Profile profile { get; set; }
        public int SharedProfileId { get; set; }
        public virtual Profile Sharedprofile { get; set; }
    }
}
