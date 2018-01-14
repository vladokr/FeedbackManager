using FM.Business.Interfaces.Exceptions;
using FM.Common.Intercases.Loggers;
using FM.Data.Access.Interfaces.Exceptions;
using FM.WebApi.common;
using FM.WebApi.Exceptions;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace FM.WebApi.filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        ILogger logger;

        public ExceptionFilter(ILogger Logger)
        {
            this.logger = Logger;
        }

        public override void OnException(HttpActionExecutedContext context)
        {          
            // Data Access Layer Exceptions.
            // Business Layer Exceptions.
            // Web API Exceptions.
            if (context.Exception is IDataAccessException ||
                context.Exception is IBusinessException ||
                context.Exception is RestApiException
                )
            {
                var error = new
                {
                    message = context.Exception?.Message,
                    detail = context.Exception.InnerException?.Message
                };
                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, error);
                logger.LogInfo(this, context.Exception);
            }
            // Not handled Exceptions.
            else
            {
                var error = new
                {
                    message = context.Exception?.Message,
                };
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, error);
                logger.LogError(this, context.Exception);
            }          
        }
    }
}