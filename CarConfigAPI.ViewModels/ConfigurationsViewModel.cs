using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigAPI.ViewModels
{
    public class ConfigurationsViewModel
    {
        public int totalPrice { get; set; }
        public string description { get; set; }
        public int user { get; set; }
        public int car { get; set; }
        public List<Parts> pickedParts { get; set; }
        public bool isPrivate { get; set; }
    }
}
