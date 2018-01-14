using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace FM.WebApi.Attributes
{
    /// <summary>
    /// Extends the AuthorizeAttribute to return Forbidden = 403 in case of failed authorization.
    /// </summary>
    public class WebApiAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// We are handling only unauthorized requests, 
        /// because the authentications is already done in the delegating handlers.
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
            actionContext.Response.StatusCode = System.Net.HttpStatusCode.Forbidden;
        }
    }
}