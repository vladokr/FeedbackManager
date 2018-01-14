using FM.Business.Interfaces;
using FM.Domain.Model.Entities;
using FM.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FM.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        IUserBusinessService userBusinessService;

        public UsersController(IUserBusinessService UserBusinessService)
        {
            this.userBusinessService = UserBusinessService;
        }

        // GET /users
        [WebApiAuthorize(Roles = Role.OPERATOR)]
        public IEnumerable<User> Get()
        {
            return userBusinessService.SelectAll();
        }
    }
}
