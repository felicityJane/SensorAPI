using System.Web.Http;
using Owin;
using SensorAPI.Repositories;
using Unity;
using Unity.AspNet.WebApi;

//using Owin;

namespace SensorAPI
{
    public static class WebApiConfig
    {
        public static void Configure(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            var container = new UnityContainer();
            container.RegisterType<ISensorRepository, SensorRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }
}
