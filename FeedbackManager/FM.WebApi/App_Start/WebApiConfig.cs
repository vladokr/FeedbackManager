using FM.WebApi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace FM.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // set the unity container
            var container = UnityContainerBuilder.getContainer();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
