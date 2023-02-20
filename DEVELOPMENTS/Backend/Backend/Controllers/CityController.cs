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
    public class CityController : ApiController
    {
        public EntityRepository<City> _cityRepository = null;

        public CityController(EntityRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        [Route("api/city")]
        public HttpResponseMessage GetAllCity()
        {
            var listOfCity = _cityRepository.FindAll();
            return Request.CreateResponse(HttpStatusCode.OK, listOfCity);
        }
    }
}
