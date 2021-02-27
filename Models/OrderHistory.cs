using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace backend.Models
{
    public partial class OrderHistory
    {
        public uint IdCourier { get; set; }
        public ulong IdOrder { get; set; }
        public string IdVehicle { get; set; }
        public uint TimeElapsed { get; set; }

        [JsonIgnore]
        public virtual Staff courier { get; set; }
        public virtual Order order { get; set; }
        public virtual Vehicle vehicle { get; set; }
    }
}
