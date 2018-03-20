using IdentityWebApi.Controllers;
using IdentityWebApi.Models;
using IdentityWebApi.Models.GroupItems;
using IdentityWebApi.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Services
{
    public class DataContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext dataContext)
        {
            
            var store = new UserStore<ApplicationUser>(dataContext);
            var userManager = new ApplicationUserManager(store);
            var Corax = new Section
            
            {
                Name = "Corax"
            };

            var Sesam = new Section
            {
                Name = "Sesam"
            };

            var Serum = new Section
            {
                Name = "Serum"
            };

            var Sobra = new Section
            {
                Name = "Sobra"
            };

            var Grythyttan = new Section
            {
                Name = "Grythyttan"
            };

            var Qultura = new Section
            {
                Name = "Qultura"
            };

            var Teknat = new Section
            {
                Name = "Teknat"
            };

            var GIH = new Section
            {
                Name = "GIH"
            };

            dataContext.Section.Add(Corax);
            dataContext.Section.Add(Sesam);
            dataContext.Section.Add(Serum);
            dataContext.Section.Add(Sobra);
            dataContext.Section.Add(Grythyttan);
            dataContext.Section.Add(Qultura);
            dataContext.Section.Add(Teknat);
            dataContext.Section.Add(GIH);
            dataContext.SaveChanges();

            var examplePerson1 = new ApplicationUser
            {
                FirstName = "Jesper",
                LastName = "Andersson",
                Password = "test",
                Email = "jesper@live.se",
                UserName = "Jesper",
                Role = "Kodapa"
            };
            var exampleGroup = new Group
            {
                Name = "Gruppen",
                SectionId = 2
            };
            dataContext.Users.Add(examplePerson1);
            dataContext.Group.Add(exampleGroup);
            dataContext.SaveChanges();

            var exampleGroupPost = new GroupPost
            {

                Title = "Ojoj",
                Description = "HAHHAH",
                Text = "MAMXMAMXMXMMXAMAMXAMXMAMX",
                DateTime = DateTime.Now,
                Picture = null,
                SenderId = examplePerson1.Id,
                GroupId = 1
            };

            dataContext.GroupPost.Add(exampleGroupPost);
            dataContext.SaveChanges();

        }
    }
}