﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI
{
    public partial class Users
    {
        public Users()
        {
            Configurations = new HashSet<Configurations>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Configurations> Configurations { get; set; }
    }
}