using FM.WebApi.common;
using System.Web.Http;

namespace FM.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // set the unity container
            var container = UnityContainerBuilder.getContainer();
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
