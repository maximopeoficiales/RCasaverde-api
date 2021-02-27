using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Soat
    {
        public Soat()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public uint Id { get; set; }
        public uint IdStatus { get; set; }
        public DateTime DueDate { get; set; }
        public string DocumentUrl { get; set; }

        public virtual SoatStatus IdStatusNavigation { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
