using System;
using System.Collections.Generic;
using System.Web;

namespace Web_Api.Models
{
    public class Challenges
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int CompetitionId { get; set; }

        public Competition Competition { get; set; }

    }
}