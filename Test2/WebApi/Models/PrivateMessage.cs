using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class PrivateMessage
    {
       
        public int MessageID{ get; set; }
        public string MessageText { get; set; }
        public User Reciever { get; set; }
        public User Sender { get; set; }

        public int SenderId { get; set; }
        public int ReciverId { get; set; }
    }
}