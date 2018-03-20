using NyttWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api.Repositories;
using Web_Api.Services;

namespace NyttWebApi.Controllers
{
    public class SectionController : ApiController
    {
        private DataContext dataContext = new DataContext();
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
