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
            if (ConnectionStringProvider == null)
            {
                throw new LinqToSqlDataAccessException("Constructor initialization failed.", new ArgumentNullException("ConnectionStringProvider"));
            }

            this.csProvider = ConnectionStringProvider;
        }

        public void Insert(Feedback item)
        {
            using (FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.csProvider.ConnectionString))
            {
                try
                {
                    FM_Feedback fm_feedback = EntityMapper.MapToDatabase<Feedback, FM_Feedback>(item);
                    dataContext.FM_Feedbacks.InsertOnSubmit(fm_feedback);
                    dataContext.SubmitChanges();

                }
                catch (Exception ex)
                {
                    throw new LinqToSqlDataAccessException("Unable to Insert Feedback", ex);
                }
            }
        }

        public IList<Feedback> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Feedback SelectById(int id)
        {
            using (FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.csProvider.ConnectionString))
            {
                try
                {
                    var fm_feedback = dataContext.FM_Feedbacks.Where(f => f.id == id).FirstOrDefault<FM_Feedback>();
                    if (fm_feedback != null)
                    {
                        return EntityMapper.MapToModel<Feedback, FM_Feedback>(fm_feedback);
                    }
                }
                catch(Exception ex)
                {
                    throw new LinqToSqlDataAccessException("Unable to Select Feedback By Id id=" + id, ex);
                }
            }

            return null;
        }
    }
}
