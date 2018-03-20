using System;
using System.Collections.Generic;
using System.Web;
using Web_Api.Models.GroupItems;

namespace Web_Api.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int TotalPoints { get; set; }
        public int CompetitionId { get; set; }
        public int GroupId { get; set; }

        public Group Group { get; set; }
        public Competition Competition { get; set; }
    }
}