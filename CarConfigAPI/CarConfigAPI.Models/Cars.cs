using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI.CarConfigAPI.Models
{
    public partial class Cars
    {
        public int Id { get; set; }
        public string BodyType { get; set; }
        public string Brand { get; set; }
        public string DrivetrainType { get; set; }
        public string ImageFolder { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public bool Unused { get; set; }
    }
}
