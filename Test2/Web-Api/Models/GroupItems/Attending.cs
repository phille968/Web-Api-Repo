using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Web_Api.Models.GroupItems
{
    public class Attending
    {
        
        public int Id { get; set; }
        public bool ÍsComing { get; set; }

        public User User { get; set; }
        public GroupPost GroupPost { get; set; }

    }
}