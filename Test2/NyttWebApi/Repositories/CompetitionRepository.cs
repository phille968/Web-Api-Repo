﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api.Models;
using Web_Api.Repositories.Base;
using Web_Api.Services;

namespace Web_Api.Repositories
{
    public class CompetitionRepository : Repository<Competition>
    {
        public CompetitionRepository(DataContext context) : base(context)
        {

        }
    }
}