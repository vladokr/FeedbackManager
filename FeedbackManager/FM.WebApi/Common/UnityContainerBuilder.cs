using FM.Business.Interfaces;
using FM.Business.Services;
using FM.Data.Access.Impl.LinqSql.DataAccess;
using FM.Data.Access.Interfaces;
using FM.Data.Access.Interfaces.Common;
using FM.WebApi.Controllers;
using FM.WebApi.DataConnection;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace FM.WebApi.common
{
    public static class UnityContainerBuilder
    {
        public static IUnityContainer getContainer()
        {
            IUnityContainer container = new UnityContainer();
          
            // business layer
            container.RegisterType<IUserBusinessService, UserBusinessService>();
            container.RegisterType<IFeedbackBusinessService, FeedbackBusinessService>();

            // access layer
            container.RegisterType<IFeedbackDataAccess, FeedbackDataAccessLS>();
            container.RegisterType<IGameDataAccess, GameDataAccessLS>();
            container.RegisterType<IGameSessionDataAccess, GameSessionDataAccessLS>();
            container.RegisterType<IUserDataAccess, UserDataAccessLS>();
            container.RegisterType<IConnectionStringProvider, ConnectionStringProvider>();

            // api
            container.RegisterType<FeedbacksController>();
            container.RegisterType<UsersController>();
            
            return container;
        }
    }
}