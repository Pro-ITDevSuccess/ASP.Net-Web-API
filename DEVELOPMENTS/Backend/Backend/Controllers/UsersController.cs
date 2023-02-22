using Backend.Business;
using Backend.Entity;
using Backend.Entity.Services;
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
        public async Task<HttpResponseMessage> FindAllUsers()
        {
            /*
            EntityRepository<User> value = new EntityRepository<User>();
            var listOfAllUser = value.FindAll();
            */
            List<User> listOfAllUser = await _usersRepository.FindAll();

            return Request.CreateResponse(HttpStatusCode.OK, listOfAllUser);
        }

        [HttpGet]
        [Route("api/users")]
        public async Task<HttpResponseMessage> FindUserById([FromUri] Guid Id)
        {
            var user = await _usersRepository.FindById(Id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "L'id de l'utisateur saisi n'existe pas !");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
        }

        [HttpPost]
        [Route("api/users/add")]
        public HttpResponseMessage AddUser([FromBody] UserReq userInput)
        {
            /*
            User user = new User();
    
            user.User_FirstName = userInput.User_FirstName;
            user.User_LastName = userInput.User_LastName;
            user.User_BirthDay = userInput.User_BirthDay;
            user.User_CIN = userInput.User_CIN;
            user.User_Genre = userInput.User_Genre;
            user.Contacts = new List<Contacts> ();
            foreach (var item in userInput.User_Contact)
            {
                user.Contacts.Add(new Contacts
                {
                    Email = item.Email,
                    Number = item.Number
                });
            }
            */

            var user = MapUser(userInput);

            _usersRepository.SaveOrUpdate(user);
            return Request.CreateResponse(HttpStatusCode.Created, "Utilisateur Enregistrer !");  
        }

        private User MapUser(UserReq userInput)
        {
            return new User
            {
                User_FirstName = userInput.User_FirstName,
                User_LastName = userInput.User_LastName,
                User_BirthDay = userInput.User_BirthDay,
                User_CIN = userInput.User_CIN,
                User_Genre = userInput.User_Genre,
                User_Country = userInput.User_Country.Select(c => new Country 
                { 
                    Country_Name = c.Country_Name,
                    Code_Postal = c.Code_Postal
                }).ToList(),
                
                User_City = userInput.User_City.Select(c => new City
                {
                    City_Name = c.City_Name,
                }).ToList(),
                
                User_Contacts = userInput.User_Contact.Select(c => new Contacts
                {
                    Email = c.Email,
                    Number = c.Number
                }).ToList()
            };
        }

        [HttpPatch]
        [Route("api/users/update")]
        public async Task<HttpResponseMessage> UpdateUser([FromUri] Guid Id,[FromBody] UserReq userInput)
        {
            var idUser = await _usersRepository.FindById(Id);
            if (idUser == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Utilisateur N'exista Pas !");
            }

            idUser.User_FirstName = userInput.User_FirstName;
            idUser.User_LastName = userInput.User_LastName;
            idUser.User_BirthDay = userInput.User_BirthDay;
            idUser.User_CIN = userInput.User_CIN;
            idUser.User_Genre = userInput.User_Genre;

            _usersRepository.SaveOrUpdate(idUser);

            return Request.CreateResponse(HttpStatusCode.OK, "Utilisateur Mise à Jour !");
        }

        [HttpDelete]
        [Route("api/users/delete")]
        public async Task<HttpResponseMessage> DeletUser([FromUri] Guid Id)
        {
            var idUser = await _usersRepository.FindById(Id);
            if (idUser == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Utilisateur N'exista Pas !");
            }
            await _usersRepository.DeleteById(Id);
            return Request.CreateResponse(HttpStatusCode.OK, "Utilisateur Supprimer avec Succes !");
        }
    }
}
