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
            return feedbackBusinessService.SelectFeedbackByRating(1);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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
            return feedbackBusinessService.CreateFeedback(feedback);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
