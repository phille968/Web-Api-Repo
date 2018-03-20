using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityWebApi.Models;
using IdentityWebApi.Repositories.Base;
using IdentityWebApi.Services;

namespace IdentityWebApi.Repositories
{
    public class CompetitionRepository : Repository<Competition>
    {
        public CompetitionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}