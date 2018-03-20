using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web_Api.Models;
using Web_Api.Models.GroupItems;

namespace NyttWebApi.Models.GroupItems
{
    public class GroupEvent
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
        public DateTime TimeForEvent { get; set; }
        public string Location { get; set; }
        public Byte[] Picture { get; set; }

        public Group Group { get; set; }
        public User Sender { get; set; }

        public int SenderId { get; set; }
        public int GroupId { get; set; }
    }
}