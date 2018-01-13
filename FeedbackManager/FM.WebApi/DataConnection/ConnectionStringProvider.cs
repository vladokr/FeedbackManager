using FM.Data.Access.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FM.WebApi.DataConnection
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["FeedbackManagerConnectionString"].ConnectionString;
    }
}