using FM.WebApi.common;
using System.Web.Http;

namespace FM.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Set unity container.
            var container = UnityContainerBuilder.getContainer();
            config.DependencyResolver = new UnityResolver(container);

            // Attribute routing.
            config.MapHttpAttributeRoutes();
           
            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            

        }
    }
}
