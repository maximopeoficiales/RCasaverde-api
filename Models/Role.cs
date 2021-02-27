using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace backend.Models
{
    public partial class Role
    {
        public Role()
        {
            users = new HashSet<User>();
            staff = new HashSet<Staff>();
        }

        public uint Id { get; set; }
        public string Role1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> users { get; set; }
        [JsonIgnore]
        public virtual ICollection<Staff> staff { get; set; }
    }
}
