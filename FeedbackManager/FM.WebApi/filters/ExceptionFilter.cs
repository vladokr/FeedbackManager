using FM.WebApi.common;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace FM.WebApi.filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Error error = new Error();
            /*
            if (context.Exception is IAccessException)
            {
                error.message = context.Exception?.Message;
                error.detail = context.Exception.InnerException?.Message;
            }
            else
            if (context.Exception is IBusinessException)
            {
                error.message = context.Exception?.Message;
                error.detail = context.Exception.InnerException?.Message;
            }
            else
            {
                error.message = context.Exception?.Message;
            }
            */
            context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, error);
        }
    }
}