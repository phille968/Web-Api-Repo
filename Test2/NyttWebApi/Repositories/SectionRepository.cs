using NyttWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api.Repositories.Base;
using Web_Api.Services;

namespace Web_Api.Repositories
{
    public class SectionRepository : Repository<Section>
    {
        public SectionRepository(DataContext context) : base(context)
        {

        }
    }
}