using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Models.GroupItems
{
    public class GroupMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public ApplicationUser Sender { get; set; }
        public Group Group { get; set; }

        public string SenderId { get; set; }
        public int GroupId { get; set; }

    }
}