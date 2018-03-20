using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class User 
    {
        public User()
        {
            this.Group = new HashSet<Group>();
            PrivateMessageReciever = new HashSet<PrivateMessage>();
            PrivateMessageSender = new HashSet<PrivateMessage>();
        }
        [Key]
        public long Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        public string Role { get; set; }


        public byte[] ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<Group> Group { get; set; }
        public ICollection<PrivateMessage> MessageReciever { get; set; }
        public ICollection<PrivateMessage> MessageSender { get; set; }

    }
}