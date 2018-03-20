using System;
using System.Collections.Generic;
using System.Web;
using Web_Api.Models.GroupItems;

namespace Web_Api.Models
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