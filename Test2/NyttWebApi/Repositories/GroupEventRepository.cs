using NyttWebApi.Models.GroupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api.Repositories.Base;
using Web_Api.Services;

namespace NyttWebApi.Repositories
{
    public class GroupEventRepository : Repository<GroupEvent>
    {
        public GroupEventRepository(DataContext context) : base(context)
        {

        }

    }
}