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
    public class CountryController : ApiController
    {
        [HttpGet]
        [Route("api/country")]
        public HttpResponseMessage GetAllCountry()
        {
            EntityRepository<Country> value = new EntityRepository<Country>();
            var allCountry = value.FindAll();

            return Request.CreateResponse(HttpStatusCode.OK, allCountry);
        }
    }
}
