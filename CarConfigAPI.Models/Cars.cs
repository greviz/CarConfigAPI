using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI
{
    public partial class Cars
    {
        public Cars()
        {
            AvailableCarParts = new HashSet<AvailableCarParts>();
            Configurations = new HashSet<ConfigurationViewModel>();
        }

        public int Id { get; set; }
        public string BodyType { get; set; }
        public string Brand { get; set; }
        public string DrivetrainType { get; set; }
        public string ImageFolder { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public bool Unused { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<AvailableCarParts> AvailableCarParts { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<ConfigurationViewModel> Configurations { get; set; }
    }
}
