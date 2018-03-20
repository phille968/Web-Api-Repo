using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityWebApi.Models.GroupItems;
using IdentityWebApi.Repositories.Base;
using IdentityWebApi.Services;

namespace IdentityWebApi.Repositories
{
    public class GroupPostRepository : Repository<GroupPost>
    {
        public GroupPostRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}