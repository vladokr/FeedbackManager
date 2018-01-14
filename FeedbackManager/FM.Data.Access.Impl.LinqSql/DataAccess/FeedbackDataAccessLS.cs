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
using System.Linq.Expressions;

namespace FM.Data.Access.Impl.LinqSql.DataAccess
{
    public class FeedbackDataAccessLS : IFeedbackDataAccess
    {
        IAppConfig appConfig;

        public FeedbackDataAccessLS(IAppConfig AppConfig)
        {
            if (AppConfig == null)
            {
                throw new LinqToSqlDataAccessException("FeedbackDataAccessLS initialization failed.", new ArgumentNullException("AppConfig"));
            }

            this.appConfig = AppConfig;
        }

        public Feedback Insert(Feedback item)
        {
            using (FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.appConfig.ConnectionString))
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
            return SelectMany(null);
        }

        public Feedback SelectById(int id)
        {
            return SelectSingle(x => x.id == id);
        }

        public IList<Feedback> SelectByRatingPaging(int Rating, int PageIndex = 1, int PageSize = 15)
        {
            IList<Feedback> feedbacks = new List<Feedback>();
            int skipRows = (PageIndex - 1) * PageSize;
            using (FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.appConfig.ConnectionString))
            {
                try
                {
                    var dataItems = dataContext.FM_Feedbacks
                                              .Where(x => x.rating >= Rating)
                                              .OrderByDescending(x => x.create_date)
                                              .Skip(skipRows)
                                              .Take(PageSize);
                    if (dataItems != null)
                    {
                        foreach (var item in dataItems)
                        {
                            Feedback model = EntityMapper.MapToModel<Feedback, FM_Feedback>(item);
                            feedbacks.Add(model);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new LinqToSqlDataAccessException("Unable to SelectByRating.", ex);
                }
            }
            return feedbacks;
        }

        #region Private General Select Methods
        private Feedback SelectSingle(Expression<Func<FM_Feedback, bool>> criteria)
        {
            if (criteria != null)
            {
                return SelectMany(criteria).SingleOrDefault();
            }

            return null;
        }

        private IList<Feedback> SelectMany(Expression<Func<FM_Feedback, bool>> Criteria)
        {
            IList<Feedback> feedbacks = new List<Feedback>();
            using (FeedbackManagerDataContext dataContext = new FeedbackManagerDataContext(this.appConfig.ConnectionString))
            {
                try
                {
                    // If criteria is Null select all.
                    IEnumerable<FM_Feedback> dataItems = Criteria == null ? 
                                                         dataContext.FM_Feedbacks : 
                                                         dataContext.FM_Feedbacks.Where(Criteria);

                
                    if (dataItems != null)
                    {
                        foreach (var item in dataItems)
                        {
                            Feedback model = EntityMapper.MapToModel<Feedback, FM_Feedback>(item);
                            feedbacks.Add(model);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new LinqToSqlDataAccessException("Unable to Select Many.", ex);
                }
            }

            return feedbacks;
        }
        #endregion

    }
}
