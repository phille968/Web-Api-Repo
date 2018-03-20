using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace Web_Api.Models.GroupItems
{
    public class Group
    {
        public Group()
        {
            this.Users = new HashSet<User>();
            GroupMessageReciever = new HashSet<GroupMessage>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Section { get; set; }
        [Required]
        public bool IsIntroGroup { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public ICollection<GroupMessage> GroupMessageReciever { get; set; }
    }

}