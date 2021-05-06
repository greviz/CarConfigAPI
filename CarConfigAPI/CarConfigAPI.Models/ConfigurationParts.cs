using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI.CarConfigAPI.Models
{
    public partial class ConfigurationParts
    {
        public int Id { get; set; }
        public int ConfigurationId { get; set; }
        public int PartId { get; set; }
    }
}
