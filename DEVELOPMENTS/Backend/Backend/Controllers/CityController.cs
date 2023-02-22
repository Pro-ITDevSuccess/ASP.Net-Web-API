using Backend.Business;
using Backend.Entity;
using Backend.Entity.Services;
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
        /*
        [HttpPost]
        [Route("api/city/add")]
        public HttpResponseMessage AddCity([FromBody] CityReq cityInput)
        {
            var city = MapCity(cityInput);

            _cityRepository.SaveOrUpdate(city);
            return Request.CreateResponse(HttpStatusCode.OK, "City Enregistrer !");
        }

        private City MapCity(CityReq cityInput)
        {
            return new City
            {
                City_Name = cityInput.City_Name
            };
        }

        */
    }
}
