using FM.Business.Interfaces;
using FM.Domain.Model.Entities;
using FM.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
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

        // GET /feedbacks/3
        [WebApiAuthorize(Roles = Role.OPERATOR)]
        [Route("feedbacks/{id:min(1)}")]
        public IHttpActionResult Get(int Id)
        {
            Feedback feedback = feedbackBusinessService.SelectById(Id);
            return Ok(feedback);
        }

        // GET /feedbacks/rating/2
        [WebApiAuthorize(Roles = Role.OPERATOR)]
        [Route("feedbacks/rating/{rating:range(1,5)}")]
        public IHttpActionResult GetByRating(int Rating)
        {
            IEnumerable<Feedback> feedbacks = feedbackBusinessService.SelectByRating(Rating);
            return Ok(feedbacks);
        }

        // POST /feedbacks/GUID
        [Route("feedbacks/{sessionId:guid}")]
        [WebApiAuthorize(Roles = Role.PLAYER)]
        public IHttpActionResult Post([FromBody]Feedback feedback, Guid sessionId)
        {
            if (ModelState.IsValid)
            {
                feedback.SessionIdentifier = sessionId;
                feedback.UserLogin = Thread.CurrentPrincipal.Identity.Name;
                Feedback feedbackStored = feedbackBusinessService.Create(feedback);
                return Ok(feedbackStored);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
