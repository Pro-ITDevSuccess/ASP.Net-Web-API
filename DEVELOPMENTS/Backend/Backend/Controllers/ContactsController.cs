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
    public class ContactsController : ApiController
    {
        public EntityRepository<Contacts> _contactsRepository = null;

        public ContactsController(EntityRepository<Contacts> contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        [HttpGet]
        [Route("api/contacts")]
        public HttpResponseMessage GetAllContact()
        {
            var getAllContact = _contactsRepository.FindAll();
            return Request.CreateResponse(HttpStatusCode.OK, getAllContact);
        }
    }
}
