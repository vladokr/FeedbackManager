using FM.Data.Access.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Domain.Model.Entities;
using FM.Data.Access.Interfaces.Common;
using FM.Data.Access.Impl.LinqSql.Exceptions;
using FM.Data.Access.Impl.LinqSql.GeneratedDAL;
using AutoMapper;
using FM.Data.Access.Impl.LinqSql.Mappers;

namespace FM.Data.Access.Impl.LinqSql.DataAccess
{
    public class FeedbackDataAccessLS : IFeedbackDataAccess
    {
        IConnectionStringProvider csProvider;

        public FeedbackDataAccessLS(IConnectionStringProvider ConnectionStringProvider)
        {
            if(ConnectionStringProvider == null)
            {
                throw new LinqToSqlDataAccessException("Constructor initialization failed.", new ArgumentNullException("ConnectionStringProvider"));
            }

            this.csProvider = ConnectionStringProvider;
        }

        public Feedback Insert(Feedback item)
        {
            throw new NotImplementedException();
        }

        public Feedback SelectById(int id)
        {
            FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.csProvider.ConnectionString);

            var fm_feedback = dataContext.FM_Feedbacks.Where(f => f.id == id).FirstOrDefault<FM_Feedback>();
            if (fm_feedback != null)
            {
                return EntityMapper.MapToModel<Feedback,FM_Feedback>(fm_feedback);
            }

            return null;
        }
    }
}
