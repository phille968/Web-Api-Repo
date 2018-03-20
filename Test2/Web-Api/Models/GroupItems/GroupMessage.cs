using System;
using System.Collections.Generic;
using System.Web;

namespace Web_Api.Models.GroupItems

{
    public class GroupMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public User Sender { get; set; }
        public Group Group { get; set; }

        public int SenderId { get; set; }
        public int GroupId { get; set; }

    }
}