using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FM.WebApi.Exceptions
{
    public class RestApiException : Exception
    {
        public RestApiException() : base() { }
        public RestApiException(string message) : base(message) { }
        public RestApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}