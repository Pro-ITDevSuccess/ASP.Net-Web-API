using Backend.Business;
using Backend.Entity;
using Backend.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace Backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            UnityContainer unityContainer = new UnityContainer();
            SetDependencies(unityContainer);
            config.DependencyResolver = new UnityResolver(unityContainer);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void SetDependencies(UnityContainer container)
        {
            //container.RegisterType<EntityRepository<User>, UserRepository>();
            container.RegisterType<EntityRepository<User>>();
        }
    }
}
