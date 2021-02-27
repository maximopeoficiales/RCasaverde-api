using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace backend.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            UserCoupons = new HashSet<UserCoupon>();
            UserReviews = new HashSet<UserReview>();
        }

        public ulong Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ClientAddress { get; set; }
        public uint Zipcode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public sbyte Active { get; set; }
        public uint IdRole { get; set; }

        public virtual Role role { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserCoupon> UserCoupons { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserReview> UserReviews { get; set; }
    }
}
