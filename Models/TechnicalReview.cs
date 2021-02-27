using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class TechnicalReview
    {
        public uint Id { get; set; }
        public string IdVehicle { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string DocumentUrl { get; set; }

        public virtual Vehicle IdVehicleNavigation { get; set; }
    }
}
