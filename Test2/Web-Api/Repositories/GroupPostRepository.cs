using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api.Models.GroupItems;
using Web_Api.Repositories.Base;
using Web_Api.Services;

namespace Web_Api.Repositories
{
    public class GroupPostRepository : Repository<GroupPost>
    {
        public GroupPostRepository(DataContext context) : base(context)
        {

        }
    }
}