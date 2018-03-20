using IdentityWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IdentityWebApi.Repositories;
using IdentityWebApi.Services;

namespace IdentityWebApi.Controllers
{
    public class SectionController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private SectionRepository sectionRepository;
      
        public SectionController()
        {
            sectionRepository = new SectionRepository(dataContext);
        }

        public IEnumerable<Section> Get()
        {
            var allSections = sectionRepository.ShowAll().ToList();

            return allSections;
        }
    }
}
