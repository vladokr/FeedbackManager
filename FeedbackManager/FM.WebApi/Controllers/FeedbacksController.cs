using FM.Business.Interfaces;
using FM.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FM.WebApi.Controllers
{
    public class FeedbacksController : ApiController
    {

        IFeedbackBusinessService feedbackBusinessService;

        public FeedbacksController(IFeedbackBusinessService feedbackBusinessService)
        {
            this.feedbackBusinessService = feedbackBusinessService;
        }

        // GET /feedbacks
        [Route("feedbacks")]
        public IEnumerable<Feedback> Get()
        {
            return feedbackBusinessService.SelectByRating(1);
        }

        // POST api/feedbacks
        [Route("feedbacks/{sessionId:guid}")]
        public Feedback Post([FromBody]Feedback feedback, Guid sessionId)
        {
            if (ModelState.IsValid)
            {
                feedback.SessionIdentifier = sessionId;
                feedback.UserLogin = "vladokr";
            }
            return feedbackBusinessService.Create(feedback);
        }
    }
}
