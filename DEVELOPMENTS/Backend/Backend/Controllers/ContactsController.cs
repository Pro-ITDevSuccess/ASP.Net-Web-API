using Backend.Business;
using Backend.Entity;
using Backend.Entity.Services;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Controllers
{
    public class ContactsController : ApiController
    {
        public EntityRepository<Contacts> _contactsRepository = null;
        public EntityRepository<User> _usersRepository = null;

        public ContactsController(EntityRepository<Contacts> contactsRepository, EntityRepository<User> usersRepository)
        {
            _contactsRepository = contactsRepository;
            _usersRepository = usersRepository;
        }   

        [HttpGet]
        [Route("api/contacts")]
        public HttpResponseMessage GetAllContacts()
        {
            var getAllContact = _contactsRepository.FindAll();
            return Request.CreateResponse(HttpStatusCode.OK, getAllContact);
        }
        
        /*
        [HttpPost]
        [Route("api/contacts/add")]
        public async Task<HttpResponseMessage> AddContacts([FromBody] Contacts contactInput, [FromBody] Guid User_Id)
        {
            var specificUser = await _usersRepository.FindById(User_Id);

            if (specificUser == null)
            {
                //return Request.CreateResponse(HttpStatusCode.NotFound, RedirectToAction("Index", "Users"));
                return Request.CreateResponse(HttpStatusCode.NotFound, "Utilisateur d'existe Pas !");
            }

            specificUser.Contacts.Add(contactInput);
            _usersRepository.SaveOrUpdate(specificUser);

            return Request.CreateResponse(HttpStatusCode.OK, "Utilisateur d'existe Pas !");
        }
         */
    }
}
