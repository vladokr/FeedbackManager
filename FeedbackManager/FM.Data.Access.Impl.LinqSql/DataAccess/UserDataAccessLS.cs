using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Data.Access.Interfaces;
using FM.Domain.Model.Entities;

namespace FM.Data.Access.Impl.LinqSql.DataAccess
{
    public class UserDataAccessLS : IUserDataAccess
    {
        public User Insert(User item)
        {
            throw new NotImplementedException();
        }

        public User SelectById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
