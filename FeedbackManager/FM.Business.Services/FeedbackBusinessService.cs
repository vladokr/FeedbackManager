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
    public class FeedbackBusinessService : IFeedbackBusinessService
    {
        IFeedbackDataAccess feedbackDataAccess;

        public FeedbackBusinessService(IFeedbackDataAccess FeedbackDataAccess)
        {
            if(FeedbackDataAccess == null)
            {
                throw new BusinessException("Constructor initialization failed.", new ArgumentNullException("FeedbackDataAccess"));
            }

            this.feedbackDataAccess = FeedbackDataAccess;
        }

        public void CreateFeedback(Feedback feedback)
        {
            feedbackDataAccess.Insert(feedback);
        }

        public IList<Feedback> SelectFeedbackByrating(int rating)
        {
            throw new NotImplementedException();
        }
    }
}
