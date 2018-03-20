using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Models
{
    public class NewsPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public Byte[] Picture { get; set; }

        public int SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
    }
}