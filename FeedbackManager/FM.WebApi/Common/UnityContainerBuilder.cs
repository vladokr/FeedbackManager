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

            /*
            // business layer
            container.RegisterType<ICustomerService, CustomerService>();
            // access layer
            container.RegisterType<ICustomerDataAccess<Customer>, CustomerDataAccess>();
            container.RegisterType<IOrderDataAccess<Order>, OrderDataAccess>();
            container.RegisterType<IConnectionManager, AdoConnectionManager>();
            container.RegisterType<IConnectionConfig, AppSettingConnectionConfig>();

            container.RegisterType<CustomerController>();
            */
            return container;
        }
    }
}