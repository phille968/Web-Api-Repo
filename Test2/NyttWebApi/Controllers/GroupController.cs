﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api.Models;
using Web_Api.Models.GroupItems;
using Web_Api.Repositories;
using Web_Api.Services;

namespace NyttWebApi.Controllers
{
    public class GroupController : ApiController
    {
        private DataContext dataContext = new DataContext();
        private GroupRepository groupRepository;
        private UserRepository userRepository;

        public GroupController()
        {
            groupRepository = new GroupRepository(dataContext);
            userRepository = new UserRepository(dataContext);
        }



        // GET: api/Group
        public IEnumerable<Group> Get()
        {
            var allGroups = groupRepository.ShowAll().ToList();

            return allGroups;
        }

        // GET: api/Group/5
        public Group Get(int id)
        {
            var group = groupRepository.GetById(id);

            return group;

        }

        // POST: api/Group
        [HttpPost]
        public void Post([FromBody]Group group)
        {
          groupRepository.Add(group);
           groupRepository.SaveChanges(group);
        }

        [HttpPost]
        public void AddUserToGroup(int groupId, int userId)
        {
            Group group = groupRepository.GetById(groupId);
            User user = userRepository.GetById(userId);
            user.Group.Add(group);
            group.Users.Add(user);
            dataContext.SaveChanges();
        }

        [HttpPost]
        public void RemoveUserFromGroup(int groupId, int userId)
        {
            Group group = groupRepository.GetById(groupId);
            User user = userRepository.GetById(userId);
            user.Group.Remove(group);
            group.Users.Remove(user);
            dataContext.SaveChanges();
        }


        public HttpResponseMessage Put(int id, [FromBody] Group group)
        {
            using (DataContext entities = new DataContext())
            {
                var entity = entities.Group.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Group with id = " + id.ToString() + "not found");
                }
                else
                {
                    entity.Name = group.Name;
                    entity.Section = group.Section;
                    entity.IsIntroGroup = group.IsIntroGroup;

                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
            groupRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}

