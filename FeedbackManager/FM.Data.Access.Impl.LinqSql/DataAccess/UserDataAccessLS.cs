using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Data.Access.Interfaces;
using FM.Domain.Model.Entities;
using FM.Data.Access.Interfaces.Common;
using FM.Data.Access.Impl.LinqSql.Exceptions;
using FM.Data.Access.Impl.LinqSql.GeneratedDAL;
using FM.Data.Access.Impl.LinqSql.Mappers;

namespace FM.Data.Access.Impl.LinqSql.DataAccess
{
    public class UserDataAccessLS : IUserDataAccess
    {
        IConnectionStringProvider csProvider;

        public UserDataAccessLS(IConnectionStringProvider ConnectionStringProvider)
        {
            if (ConnectionStringProvider == null)
            {
                throw new LinqToSqlDataAccessException("Constructor initialization failed.", new ArgumentNullException("ConnectionStringProvider"));
            }

            this.csProvider = ConnectionStringProvider;
        }

        public User Insert(User item)
        {
            throw new NotImplementedException();
        }

        public IList<User> Select(Func<User, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public IList<User> SelectAll()
        {
            using (FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.csProvider.ConnectionString))
            {
                try
                {
                    var allUsers = dataContext.FM_Users;             
                    if (allUsers != null)
                    {
                        IList<User> users = new List<User>();
                        foreach (var fmUser in allUsers)
                        {                          
                            User user = EntityMapper.MapToModel<User, FM_User>(fmUser);
                            users.Add(user);
                        }
                        return users;
                    }
                }
                catch (Exception ex)
                {
                    throw new LinqToSqlDataAccessException("Unable to Select All Users.", ex);
                }
            }

            return null;
        }

        public User SelectById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
