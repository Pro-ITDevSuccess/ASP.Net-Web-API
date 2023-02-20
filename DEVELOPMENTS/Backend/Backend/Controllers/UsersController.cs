using Backend.Business;
using Backend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Controllers
{
    public class UsersController : ApiController
    {
        public EntityRepository<User> _usersRepository = null;

        public UsersController(EntityRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage FindAllUser()
        {
            /*
            EntityRepository<User> value = new EntityRepository<User>();
            var listOfAllUser = value.FindAll();
            */
            var listOfAllUser = _usersRepository.FindAll();

            return Request.CreateResponse(HttpStatusCode.OK, listOfAllUser);
        }
    }
}
