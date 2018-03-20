using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityWebApi.Models.GroupItems;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace IdentityWebApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
                this.Group = new HashSet<Group>();
                PrivateMessageReciever = new HashSet<PrivateMessage>();
                PrivateMessageSender = new HashSet<PrivateMessage>();
                GroupMessageSender = new HashSet<GroupMessage>();
                IsEmailConfirmed = false;
                ConfirmToken = ReplaceCharacters("+", "/", "=");
 
        }
        public override string Email { get; set; }
        [Required]
        public override string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public override string PhoneNumber { get; set; }
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
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
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