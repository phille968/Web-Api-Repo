using NyttWebApi.Models;
using NyttWebApi.Models.GroupItems;
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
       
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsIntroGroup { get; set; }
        
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public virtual ICollection<User> Users { get; set; }
        
    }

}