using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Models
{
    public class PrivateMessage
    {
        [Key]
        public int MessageID { get; set; }
        public string MessageText { get; set; }

        public DateTime DateTime { get; set; }
        public virtual ApplicationUser Reciever { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        public string SenderId { get; set; }
        public string RecieverId { get; set; }
    }
}