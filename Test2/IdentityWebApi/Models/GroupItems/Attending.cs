using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Models.GroupItems
{
    public class Attending
    {

        public int Id { get; set; }
        public bool ÍsComing { get; set; }

        public ApplicationUser User { get; set; }
        public GroupEvent GroupEvent { get; set; }

    }
}