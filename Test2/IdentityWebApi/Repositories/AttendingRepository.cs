﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityWebApi.Models;
using IdentityWebApi.Models.GroupItems;
using IdentityWebApi.Repositories.Base;
using IdentityWebApi.Services;


namespace IdentityWebApi.Repositories
{
    public class AttendingRepository : Repository<Attending>
    {
        public AttendingRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}