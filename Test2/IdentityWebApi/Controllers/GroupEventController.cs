using IdentityWebApi.Models.GroupItems;
using IdentityWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IdentityWebApi.Services;

namespace NyttWebApi.Controllers
{
    
        public class GroupEventController : ApiController
        {
            private ApplicationDbContext dataContext = new ApplicationDbContext();
            private GroupEventRepository groupEventRepository;
            private GroupRepository groupRepository;
            private UserRepository userRepository;

            public GroupEventController()
            {
                groupEventRepository = new GroupEventRepository(dataContext);
                groupRepository = new GroupRepository(dataContext);
                userRepository = new UserRepository(dataContext);
            }



            // GET: api/GroupEvent
            public IEnumerable<GroupEvent> Get()
            {
                var allGroupEvents = groupEventRepository.ShowAll().ToList();

                return allGroupEvents;
            }

            // GET: api/GroupEvent/5
            public GroupEvent Get(int id)
            {
                var groupEvent = groupEventRepository.GetById(id);

                return groupEvent;

            }

            // POST: api/GroupEvent
            [HttpPost]
            public void Post([FromBody]GroupEvent groupEvent)
            {
                groupEventRepository.Add(groupEvent);
                groupEventRepository.SaveChanges(groupEvent);
            }

            public HttpResponseMessage Put(int groupEventId, [FromBody] GroupEvent groupEvent)
            {
                using (ApplicationDbContext entities = new ApplicationDbContext())
                {
                    var entity = entities.GroupEvent.FirstOrDefault(e => e.Id == groupEventId);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Group event with id = " + groupEventId.ToString() + "not found");
                    }
                    else
                    {
                        entity.Title = groupEvent.Title;
                        entity.Description = groupEvent.Description;
                        entity.Text = groupEvent.Text;
                        entity.TimeForEvent = groupEvent.TimeForEvent;
                        entity.Location = groupEvent.Location;
                        entity.Picture = groupEvent.Picture;
                        entity.SenderId = groupEvent.SenderId;
                        entity.GroupId = groupEvent.GroupId;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }

            // DELETE: api/Group/5
            public void Delete(int id)
            {
                groupEventRepository.Remove(id);
                dataContext.SaveChanges();
            }
        }
    }

