using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Web_Api.Models.GroupItems
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
        public User Sender { get; set; }
        
        public String SenderId { get; set; }
        public int GroupId { get; set; }

    }
}