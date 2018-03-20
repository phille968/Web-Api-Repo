using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test2.Models;
using System.Web.Http.Cors;
using System.Collections;

namespace Test2.Controllers
{
    
    public class UserController : ApiController
    {
        
        // GET: api/User
        public List<User> Get()
        {
            UserPersistence u = new UserPersistence();
            return u.GetUsers();
        }

        //GET: api/User/5
        public User Get(int id)
        {
            UserPersistence u = new UserPersistence();
            User User = u.GetUser(id);
            if (User == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }


            return User;
        }

        // POST: api/User
        public HttpResponseMessage Post([FromBody]User value)
        {
            UserPersistence uP = new UserPersistence();
            long id;
            id = uP.SaveUser(value);
            //k
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("User/{0}", id));
            return response;
        }

        // PUT: api/User/5
        public HttpResponseMessage Put(int id, [FromBody]User User)
        {
            UserPersistence uP = new UserPersistence();
            bool recordExisted = false;
            recordExisted = uP.ChangeUser(id, User);
            HttpResponseMessage response;
            if (recordExisted)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);

            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }

        // DELETE: api/User/5
        public HttpResponseMessage Delete(int id)
        {
            UserPersistence uP = new UserPersistence();
            bool recordExisted = false;
            recordExisted = uP.DeleteUser(id);

            HttpResponseMessage response;

            if (recordExisted)
            {
               response = Request.CreateResponse(HttpStatusCode.NoContent);

            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;

        }
    }
}
