using IdentityWebApi.Models;
using IdentityWebApi.Repositories;
using IdentityWebApi.Security;
using IdentityWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace IdentityWebApi.Controllers
{
    public class UserController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository(dataContext);
        }



        // GET: api/User
        public IEnumerable<ApplicationUser> Get()
        {
            var allUsers = userRepository.ShowAll().ToList();

            return allUsers;
        }

        // GET: api/User/5
        public ApplicationUser Get(string id)
        {
            var user = userRepository.GetById(id);
            return user;

        }

        // POST: api/User
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody]ApplicationUser user)
        {

            var listOfUsers = userRepository.ShowAll().ToList();
            foreach (var userEmail in listOfUsers)
            {
                if (userEmail.Email == user.Email)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with email = " + user.Email + " already exists.");
                }
            }

            string uncrypted = user.Password;
            string encrypted = Encryption.Encrypt(uncrypted);
            user.Password = encrypted;

            userRepository.Add(user);
            userRepository.SaveChanges(user);

            var body = "<p>Här är din kod: " + user.ConfirmToken + "\n" + "Var vänlig bekräfta den på: http://localhost:51314/Home/Contact";
            var message = new MailMessage();
            message.To.Add(new MailAddress(user.Email));
            message.From = new MailAddress("inspark-noreplies@outlook.com");
            message.Subject = "Bekräfta din e-mailadress";
            message.Body = string.Format(body);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "inspark-noreplies@outlook.com",
                    Password = "Inspark123"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                await smtp.SendMailAsync(message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }




        public HttpResponseMessage Put(string id, [FromBody] ApplicationUser user)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                var entity = entities.Users.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id.ToString() + "not found");
                }
                else
                {
                    entity.Email = user.Email;
                    entity.UserName = user.UserName;
                    entity.Password = user.Password;
                    entity.PhoneNumber = user.PhoneNumber;
                    entity.Section = user.Section;
                    entity.Role = user.Role;
                    entity.ProfilePicture = user.ProfilePicture;
                    entity.FirstName = user.FirstName;
                    entity.LastName = user.LastName;
                    entity.IsLoggedIn = user.IsLoggedIn;

                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
        }

        // DELETE: api/User/5
        public void Delete(string id)
        {
            userRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}
