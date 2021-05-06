using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI.CarConfigAPI.Models
{
    public partial class Parts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string PrimaryType { get; set; }
        public string SecondaryType { get; set; }
    }
}
