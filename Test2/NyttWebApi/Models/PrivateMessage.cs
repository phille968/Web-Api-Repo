using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Api.Models
{
    public class PrivateMessage
    {
       [Key]
        public int MessageID{ get; set; }
        public string MessageText { get; set; }

        public DateTime DateTime { get; set; }
        public virtual User Reciever { get; set; }
        public virtual User Sender { get; set; }

        public int SenderId { get; set; }
        public int RecieverId { get; set; }
    }
}