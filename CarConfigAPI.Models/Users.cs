using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Configurations = new HashSet<Configurations>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Comments> Comments { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Configurations> Configurations { get; set; }
    }
}
