using FM.Data.Access.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FM.WebApi.Common
{
    public class WebApiAppConfig : IAppConfig
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["FeedbackManagerConnectionString"].ConnectionString;

        public string ApplicationKey => ConfigurationManager.AppSettings["FeedbackManagerApplicationKey"];

        public string AuthenticationScheme => ConfigurationManager.AppSettings["AuthenticationScheme"];

        public string AuthenticationUserLoginHeader => ConfigurationManager.AppSettings["AuthenticationUserLoginHeader"];

        public string AuthenticationUserPasswordHeader => ConfigurationManager.AppSettings["AuthenticationUserPasswordHeader"];
    }
}