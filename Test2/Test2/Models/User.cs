﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Section { get; set; }


    }
}