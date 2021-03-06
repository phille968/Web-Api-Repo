﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using IdentityWebApi.Repositories;
using IdentityWebApi.Services;

namespace IdentityWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ConfirmEmailController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private UserRepository userRepository;

        public ConfirmEmailController()
        {
            userRepository = new UserRepository(dataContext);
        }


        // POST: api/ConfirmEmail
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Validate(string confirmationKeyId)
        {
            var listOfUsers = userRepository.ShowAll().ToList();
            foreach (var user in listOfUsers)
            {
                if (confirmationKeyId == user.ConfirmToken && user.IsEmailConfirmed == false)
                {
                    user.IsEmailConfirmed = true;
                    dataContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Confirmation key is OK!");
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "This confirmationkey is invalid.");
        }


    }
}
