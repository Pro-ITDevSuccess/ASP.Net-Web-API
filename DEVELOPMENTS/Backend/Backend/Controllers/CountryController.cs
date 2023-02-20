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
        public EntityRepository<Country> _countryRepository = null;

        public CountryController(EntityRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        [Route("api/country")]
        public HttpResponseMessage GetAllCountry()
        {
            /*
            EntityRepository<Country> value = new EntityRepository<Country>();
            var allCountry = value.FindAll();
            */
            var allCountry = _countryRepository.FindAll();

            return Request.CreateResponse(HttpStatusCode.OK, allCountry);
        }
    }
}
