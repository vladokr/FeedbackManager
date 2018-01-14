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
using System.Linq.Expressions;

namespace FM.Data.Access.Impl.LinqSql.DataAccess
{
    public class UserDataAccessLS : IUserDataAccess
    {
        IAppConfig appConfig;

        public UserDataAccessLS(IAppConfig AppConfig)
        {
            if (AppConfig == null)
            {
                throw new LinqToSqlDataAccessException("UserDataAccessLS initialization failed.", new ArgumentNullException("AppConfig"));
            }

            this.appConfig = AppConfig;
        }

        public User Insert(User item)
        {
            throw new NotImplementedException();
        }

        public User SelectByUserLogin(string UserLogin)
        {
            return SelectSingle(x => x.user_login == UserLogin);
        }

        public IList<User> SelectAll()
        {
            return SelectMany(null);
        }

        public User SelectById(int id)
        {
            return SelectSingle(x => x.id == id);
        }

        #region Private General Select Methods
        private IList<User> SelectMany(Expression<Func<FM_User, bool>> criteria)
        {
            IList<User> users = new List<User>();
            using (FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.appConfig.ConnectionString))
            {
                try
                {
                    // If criteria is Null select all Users.
                    var allUsers = criteria == null ? dataContext.FM_Users : dataContext.FM_Users.Where(criteria);
                    if (allUsers != null)
                    {                       
                        foreach (var fmUser in allUsers)
                        {
                            User user = EntityMapper.MapToModel<User, FM_User>(fmUser);
                            users.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new LinqToSqlDataAccessException("Unable to Select Users.", ex);
                }
            }

            return users;
        }

        private User SelectSingle(Expression<Func<FM_User, bool>> criteria)
        {
            if(criteria != null)
            {
                return SelectMany(criteria).SingleOrDefault();
            }

            return null;
        }
        #endregion
    }
}
