using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Staff
    {
        public Staff()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public uint Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Dni { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public sbyte Active { get; set; }
        public uint IdRole { get; set; }

        public virtual Role role { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
