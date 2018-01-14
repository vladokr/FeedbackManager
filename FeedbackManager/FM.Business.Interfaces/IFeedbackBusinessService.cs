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
        Feedback Create(Feedback feedback);
        IList<Feedback> SelectByRating(int rating);
    }
}
