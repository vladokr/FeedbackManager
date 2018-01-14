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

        // GET /feedbacks
        [WebApiAuthorize(Roles = Role.OPERATOR)]
        public IEnumerable<Feedback> Get()
        {
            return feedbackBusinessService.SelectByRating(1);
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
                return BadRequest();
            }
        }
    }
}
