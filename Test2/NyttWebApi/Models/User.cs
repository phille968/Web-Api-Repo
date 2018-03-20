using Newtonsoft.Json;
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
            IsEmailConfirmed = false;
            ConfirmToken = ReplaceCharacters("+", "/", "=");

        }

        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Section { get; set; }
        [Required]
        public string Role { get; set; }

       
        public bool IsLoggedIn { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string ConfirmToken { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

       
        public virtual ICollection<Group> Group { get; set; }
        [JsonIgnore]
        public virtual ICollection<PrivateMessage> PrivateMessageReciever { get; set; }
        [JsonIgnore]
        public virtual ICollection<PrivateMessage> PrivateMessageSender { get; set; }
        [JsonIgnore]
        public virtual ICollection<GroupMessage> GroupMessageSender { get; set; }


        public string ReplaceCharacters(string a, string b, string c)
        {
            string input = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            string inputOne = input.Replace(a, "f");
            string inputTwo = inputOne.Replace(b, "e");
            string inputThree = inputTwo.Replace(c, "a");
            return inputThree;
        }
    }
}