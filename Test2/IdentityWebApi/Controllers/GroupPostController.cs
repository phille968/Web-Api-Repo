using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IdentityWebApi.Models.GroupItems;
using IdentityWebApi.Repositories;
using IdentityWebApi.Services;


namespace IdentityWebApi.Controllers
{
    public class GroupPostController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private GroupPostRepository groupPostRepository;
        private GroupRepository groupRepository;
        private UserRepository userRepository;

        public GroupPostController()
        {
            groupPostRepository = new GroupPostRepository(dataContext);
            groupRepository = new GroupRepository(dataContext);
            userRepository = new UserRepository(dataContext);
        }



        // GET: api/GroupEvent
        public IEnumerable<GroupPost> Get()
        {
            var allGroupPosts = groupPostRepository.ShowAll().ToList();

            return allGroupPosts;
        }

        // GET: api/GroupEvent/5
        public GroupPost Get(int id)
        {
            var groupPost = groupPostRepository.GetById(id);

            return groupPost;

        }

        // POST: api/GroupEvent
        [HttpPost]
        public void Post([FromBody]GroupPost groupPost)
        {
            groupPostRepository.Add(groupPost);
            groupPostRepository.SaveChanges(groupPost);
        }

        public HttpResponseMessage Put(int groupPostId, [FromBody] GroupPost groupPost)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
               
                var entity = entities.GroupPost.FirstOrDefault(p => p.Id == groupPostId);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Group post with id = " + groupPostId.ToString() + "not found");
                }
                else
                {
                    entity.Title = groupPost.Title;
                    entity.Description = groupPost.Description;
                    entity.Text = groupPost.Text;
                    entity.DateTime = groupPost.DateTime;
                    entity.Picture = groupPost.Picture;
                    entity.SenderId = groupPost.SenderId;
                    entity.GroupId = groupPost.GroupId;

                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
            groupPostRepository.Remove(id);
            dataContext.SaveChanges();
        }
    }
}
