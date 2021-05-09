using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigAPI.ViewModels
{
    public class CustomRequestBody
    {
        public Configurations configuration { get; set; }
        public Comments comment { get; set; }

    }
}
