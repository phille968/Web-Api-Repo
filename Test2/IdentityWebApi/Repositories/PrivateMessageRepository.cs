using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityWebApi.Models;
using IdentityWebApi.Repositories.Base;
using IdentityWebApi.Services;

namespace IdentityWebApi.Repositories
{
    public class PrivateMessageRepository : Repository<PrivateMessage>
    {
        public PrivateMessageRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}