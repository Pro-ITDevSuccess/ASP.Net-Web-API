using Backend.Business;
using Backend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage FindAllUser()
        {
            EntityRepository<User> value = new EntityRepository<User>();
            var listOfAllUser = value.FindAll();

            return Request.CreateResponse(HttpStatusCode.OK, listOfAllUser);
        }
    }
}
