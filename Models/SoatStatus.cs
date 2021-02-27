using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class SoatStatus
    {
        public SoatStatus()
        {
            Soats = new HashSet<Soat>();
        }

        public uint Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Soat> Soats { get; set; }
    }
}
