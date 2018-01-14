using FM.Business.Interfaces.Common;
using FM.Data.Access.Interfaces.Common;
using FM.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace FM.WebApi.Handlers
{
    /// <summary>
    /// Performs a simple/basic authentication on every HTTP request. 
    /// The HTTP request header must contain a Basic Authorization and the user credentials.
    /// <code> Example:
    /// Authorization: Basic QWxhZGRpbjpPcGVuU2VzYW1l
    /// X-UserLogin: UserUbi
    /// X-UserPassword: 245167j
    /// </code>
    /// </summary>
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IAuthenticationManager authenticationManager;
        private readonly IAppConfig appConfig;

        public AuthenticationHandler(IAuthenticationManager AuthenticationManager, IAppConfig AppConfig)
        {
            this.authenticationManager = AuthenticationManager;
            this.appConfig = AppConfig;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string appKey = RetreiveHeaderAuthenticationKey(request);
            // Doesn't match the application key
            if(appConfig.ApplicationKey != appKey)
            {
                return Unauthorized();
            }

            // Check Credentials
            String userLogin = RetreiveCustomHeaderValue(request, appConfig.AuthenticationUserLoginHeader);
            String userPassword = RetreiveCustomHeaderValue(request, appConfig.AuthenticationUserPasswordHeader);

            User user = authenticationManager.Authenticate(userLogin, userPassword);
            if(user != null)
            {
                // Successful authentication
                GenericIdentity identity = new GenericIdentity(userLogin, appConfig.AuthenticationScheme);
                string[] roles = new string[1]{ user.RoleId.ToString() };
                IPrincipal principal = new GenericPrincipal(identity, roles);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;


                // continue the flow invoking the other handlers
                return base.SendAsync(request, cancellationToken);
            }
            else
            {
                return Unauthorized();
            }         
        }

        private string RetreiveHeaderAuthenticationKey(HttpRequestMessage request)
        {
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            if (authorization?.Scheme == appConfig.AuthenticationScheme)
            {
                return authorization?.Parameter;
            }

            return String.Empty;
        }

        private string RetreiveCustomHeaderValue(HttpRequestMessage request, String HeaderName)
        {
            IEnumerable<string> headerValues = null;
            if(request.Headers.TryGetValues(HeaderName, out headerValues))
            {
                return headerValues.FirstOrDefault();
            }

            return String.Empty;
        }

        private Task<HttpResponseMessage> Unauthorized()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}