using IdentityWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityWebApi.Repositories.Base;
using IdentityWebApi.Services;

namespace IdentityWebApi.Repositories
{
    public class SectionRepository : Repository<Section>
    {
        public SectionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}