using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Web_Api.Models.GroupItems;

namespace Web_Api.Models
{
    public class User
    {
        public User()
        {
            this.Group = new HashSet<Group>();
            PrivateMessageReciever = new HashSet<PrivateMessage>();
            PrivateMessageSender = new HashSet<PrivateMessage>();

            GroupMessageSender = new HashSet<GroupMessage>();
        }
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public string Section { get; set; }
        [Required]
        public string Role { get; set; }


        public byte[] ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public virtual ICollection<Group> Group { get; set; }

        public virtual ICollection<PrivateMessage> PrivateMessageReciever { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessageSender { get; set; }
        public virtual ICollection<GroupMessage> GroupMessageSender { get; set; }
    }
}