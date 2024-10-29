using Drivers.Services;
using Microsoft.AspNetCore.Mvc;
using Drivers.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private FeedbacksService feedbacksService;

        // GET: api/<FeedbacksController>
        [HttpGet]
        public ActionResult<List<Feedback>> Get()
        {
            if (feedbacksService.feedbacks != null)
                return feedbacksService.feedbacks;
            return NotFound();
        }

        // GET api/<FeedbacksController>/5
        [HttpGet("{id}")]
        public ActionResult<Feedback> Get(int id)
        {
            if (feedbacksService.GetFeedbackById(id) != null)
                return feedbacksService.GetFeedbackById(id);
            return NotFound();
        }

        // POST api/<FeedbacksController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Feedback feedback)
        {
            if (feedbacksService.PostFeedback(feedback))
                return Ok(true);
            return NotFound();
        }

        // PUT api/<FeedbacksController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Feedback feedback)
        {
            if (feedbacksService.PutFeedback(id, feedback))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<FeedbacksController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (feedbacksService.DeleteFeedback(id))
                return Ok(true);
            return NotFound();
        }
    }
}
