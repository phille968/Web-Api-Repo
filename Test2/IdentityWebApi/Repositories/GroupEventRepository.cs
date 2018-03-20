using IdentityWebApi.Models.GroupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityWebApi.Repositories.Base;
using IdentityWebApi.Services;

namespace IdentityWebApi.Repositories
{
    public class GroupEventRepository : Repository<GroupEvent>
    {
        public GroupEventRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}