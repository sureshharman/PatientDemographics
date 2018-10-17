using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using PatientDemographicsRepository.BussinessLayer;

namespace PatientDemographicsRepository
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MapHttpAttributeRoutes();

            //Configuring dependency resolver
            var container = new UnityContainer();
            container.RegisterType<IPatientRepository, PatientRepo>();
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}
