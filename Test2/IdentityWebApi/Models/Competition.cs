using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }


    }
}