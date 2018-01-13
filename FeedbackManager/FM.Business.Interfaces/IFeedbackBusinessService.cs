using FM.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Business.Interfaces
{
    public interface IFeedbackBusinessService
    {
        void CreateFeedback(Feedback feedback);
        IList<Feedback> SelectFeedbackByrating(int rating);
    }
}
