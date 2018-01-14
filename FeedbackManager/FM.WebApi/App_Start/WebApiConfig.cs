using FM.WebApi.common;
using FM.WebApi.filters;
using FM.WebApi.Handlers;
using System.Web.Http;

namespace FM.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Set unity container.
            var container = UnityContainerBuilder.getContainer();
            var resolver = new UnityResolver(container);
            config.DependencyResolver = resolver;

            // Attribute routing.
            config.MapHttpAttributeRoutes();
           
            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Set message handlers.
            object authenticationHandler = container.Resolve(typeof(AuthenticationHandler), null);
            config.MessageHandlers.Add(authenticationHandler as AuthenticationHandler);

            // Set Filters.
            object exceptionFilter = container.Resolve(typeof(ExceptionFilter), null);
            config.Filters.Add(exceptionFilter as ExceptionFilter);
        }
    }
}
