using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Web_Api.Models;
using Web_Api.Models.GroupItems;
using NyttWebApi.Models;

namespace Web_Api.Services
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext dataContext)
        {
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

            var examplePerson1 = new User
            {
                FirstName = "Jesper",
                LastName = "Andersson",
                Email = "jesper@live.se",
                UserName = "Jesper",
                Password = "test",
                Role = "Kodapa"
            };
            var exampleGroup = new Group
            {
                Name = "Gruppen",
                SectionId = 2
            };

            dataContext.User.Add(examplePerson1);
            dataContext.Group.Add(exampleGroup);
            dataContext.SaveChanges();

            var exampleGroupPost = new GroupPost
            {
              
                Title = "Ojoj",
                Description = "HAHHAH",
                Text = "MAMXMAMXMXMMXAMAMXAMXMAMX",
                DateTime = DateTime.Now,
                Picture = null,
                SenderId = 1,
                GroupId = 1
            };

            dataContext.GroupPost.Add(exampleGroupPost);
            dataContext.SaveChanges();

        }
    }
}