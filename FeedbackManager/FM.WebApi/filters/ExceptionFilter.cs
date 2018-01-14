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
            Error error = new Error();

            // Data Access Layer Exceptions.
            // Business Layer Exceptions.
            // Web API Exceptions.
            if (context.Exception is IDataAccessException ||
                context.Exception is IBusinessException ||
                context.Exception is RestApiException
                )
            {
                error.message = context.Exception?.Message;
                error.detail = context.Exception.InnerException?.Message;
                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, error);
                logger.LogInfo(this, context.Exception);
            }
            // Not handled Exceptions.
            else
            {
                error.message = context.Exception?.Message;
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, error);
                logger.LogError(this, context.Exception);
            }          
        }
    }
}