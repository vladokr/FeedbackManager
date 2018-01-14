using FM.Business.Interfaces;
using FM.Business.Interfaces.Common;
using FM.Business.Services;
using FM.Business.Services.Common;
using FM.Data.Access.Impl.LinqSql.DataAccess;
using FM.Data.Access.Interfaces;
using FM.Data.Access.Interfaces.Common;
using FM.WebApi.Common;
using FM.WebApi.Controllers;
using FM.WebApi.Handlers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace FM.WebApi.common
{
    public static class UnityContainerBuilder
    {
        public static IUnityContainer getContainer()
        {
            IUnityContainer container = new UnityContainer();
          
            // Business layer
            container.RegisterType<IUserBusinessService, UserBusinessService>();
            container.RegisterType<IFeedbackBusinessService, FeedbackBusinessService>();

            // Access layer
            container.RegisterType<IFeedbackDataAccess, FeedbackDataAccessLS>();
            container.RegisterType<IGameDataAccess, GameDataAccessLS>();
            container.RegisterType<IGameSessionDataAccess, GameSessionDataAccessLS>();
            container.RegisterType<IUserDataAccess, UserDataAccessLS>();


            // WEB API

            // Registers as a Singleton
            container.RegisterType<IAppConfig, WebApiAppConfig>(new ContainerControlledLifetimeManager());
            // Registers as a Singleton, but its child classes resolves with new instances 
            container.RegisterType<IAuthenticationManager, BasicAuthenticationManager>(new HierarchicalLifetimeManager());
            
            container.RegisterType<FeedbacksController>();
            container.RegisterType<UsersController>();
            container.RegisterType<AuthenticationHandler>();

            return container;
        }
    }
}