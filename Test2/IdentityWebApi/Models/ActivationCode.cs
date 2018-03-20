using IdentityWebApi.Models.GroupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Models
{
    public class ActivationCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool Activated { get; set; }
        public int GroupId { get; set; }

        public Group Group { get; set; }

    }
}