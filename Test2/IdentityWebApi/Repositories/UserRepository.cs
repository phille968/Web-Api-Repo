using IdentityWebApi.Models;
using IdentityWebApi.Repositories.Base;
using IdentityWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Repositories
{
    public class UserRepository : Repo2<ApplicationUser>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
    
}