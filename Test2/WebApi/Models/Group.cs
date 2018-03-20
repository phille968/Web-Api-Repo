using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApi.Models
{
    public class Group
    {
        public Group()
        {
            this.Users = new HashSet<User>();
        }
        [Key]
        []
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Section { get; set; }
        
        public virtual ICollection<User> Users { get; set; }
    }

}