using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Models.GroupItems
{
    public class GroupPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public Byte[] Picture { get; set; }

        public Group Group { get; set; }
        public ApplicationUser Sender { get; set; }

        public string SenderId { get; set; }
        public int GroupId { get; set; }

    }
}