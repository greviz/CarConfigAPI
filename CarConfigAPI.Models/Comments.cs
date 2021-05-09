using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI
{
    public partial class Comments
    {
        public Comments()
        {
            ConfigurationComments = new HashSet<ConfigurationComments>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<ConfigurationComments> ConfigurationComments { get; set; }
    }
}
