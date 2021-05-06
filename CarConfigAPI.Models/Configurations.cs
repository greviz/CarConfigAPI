using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI
{
    public partial class Configurations
    {
        public Configurations()
        {
            ConfigurationParts = new HashSet<ConfigurationParts>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public int TotalPrice { get; set; }
        public bool Private { get; set; }
        public int CarId { get; set; }
        public int CreatedBy { get; set; }

        public virtual Cars Car { get; set; }
        public virtual Users CreatedByNavigation { get; set; }
        public virtual ICollection<ConfigurationParts> ConfigurationParts { get; set; }
    }
}
