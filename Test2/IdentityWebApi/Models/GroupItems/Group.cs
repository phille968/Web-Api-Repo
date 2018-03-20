using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Models.GroupItems
{
    public class Group
    {
        public Group()
        {
            this.Users = new HashSet<ApplicationUser>();

        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsIntroGroup { get; set; }

        public Section Section { get; set; }
        public int SectionId { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}