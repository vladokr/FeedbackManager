using FM.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Domain.Model.Entities;
using FM.Data.Access.Interfaces;
using FM.Business.Services.Exceptions;

namespace FM.Business.Services
{
    public class UserBusinessService : IUserBusinessService
    {
        IUserDataAccess userDataAccess;

        public UserBusinessService(IUserDataAccess UserDataAccess)
        {
            if (UserDataAccess == null)
            {
                throw new BusinessException("Constructor initialization failed.", new ArgumentNullException("UserDataAccess"));
            }

            this.userDataAccess = UserDataAccess;
        }

        public IList<User> SelectAll()
        {
            return userDataAccess.SelectAll();
        }
    }
}
