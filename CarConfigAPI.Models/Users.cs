using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI
{
    public partial class Users
    {
        public Users()
        {
            Configurations = new HashSet<ConfigurationViewModel>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<ConfigurationViewModel> Configurations { get; set; }
    }
}
