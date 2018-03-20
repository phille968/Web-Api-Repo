using NyttWebApi.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Web_Api.Models
{
    public class Competition 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }


    }
}