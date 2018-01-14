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

        public Feedback Insert(Feedback item)
        {
            using (FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.csProvider.ConnectionString))
            {
                try
                {
                    FM_Feedback fmFeedback = dataContext.sp_insert_feedback(item.Rating, item.UserLogin, item.SessionIdentifier, item.Comment)
                                                        .ToList().FirstOrDefault<FM_Feedback>();

                    return EntityMapper.MapToModel<Feedback, FM_Feedback>(fmFeedback);
                                                       
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

        public IList<Feedback> Select(Func<Feedback, bool> criteria)
        {
            using (FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.csProvider.ConnectionString))
            {
                try
                {                  
                    var data = dataContext.FM_Feedbacks.Where((fm) => criteria(EntityMapper.MapToModel<Feedback, FM_Feedback>(fm)));
                    if (data != null)
                    {
                        IList<Feedback> selectedFeedbacks = new List<Feedback>();
                        data.ToList().ForEach((fm) => {
                            Feedback feedback = EntityMapper.MapToModel<Feedback, FM_Feedback>(fm);
                            selectedFeedbacks.Add(feedback);
                        });
                        return selectedFeedbacks;
                    }
                }
                catch (Exception ex)
                {
                    throw new LinqToSqlDataAccessException("Unable to Select Feedback By Criteria", ex);
                }
            }

            return null;
        }

    }
}
