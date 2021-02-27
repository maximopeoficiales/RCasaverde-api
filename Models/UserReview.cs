using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class UserReview
    {
        public ulong IdUser { get; set; }
        public uint IdProduct { get; set; }
        public uint? Stars { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
