using FM.Business.Interfaces.Common;
using FM.Business.Services.Exceptions;
using FM.Data.Access.Interfaces;
using FM.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Business.Services.Common
{
    public class BasicAuthenticationManager : IAuthenticationManager
    {
        IUserDataAccess userDataAccess;
        public BasicAuthenticationManager(IUserDataAccess UserDataAccess)
        {
            if (UserDataAccess == null)
            {
                throw new BusinessException("BasicAuthenticationManager initialization failed.", new ArgumentNullException("UserDataAccess"));
            }

            this.userDataAccess = UserDataAccess;
        }

        /// <summary>
        /// Checks if the user is registered in the system. It performs an authentication.
        /// </summary>
        /// <param name="UserLogin">The user name.</param>
        /// <param name="UserPassword">The user password.</param>
        /// <returns>A User object if the User exists and the password matches, otherwise NULL.</returns>
        public User Authenticate(string UserLogin, string UserPassword)
        {
            if(!String.IsNullOrWhiteSpace(UserLogin) && !String.IsNullOrWhiteSpace(UserPassword))
            {
                User user = userDataAccess.SelectByUserLogin(UserLogin);
                if(user != null && user.UserPassword == UserPassword)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
