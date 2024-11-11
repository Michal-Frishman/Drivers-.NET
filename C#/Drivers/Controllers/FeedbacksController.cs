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
        private static FeedbacksService feedbacksService;
        // GET: api/<FeedbacksController>
        [HttpGet]
        public ActionResult<List<Feedback>> Get()
        {
            return DataContextManager.DataContext.feedbacks;
         
        }

        // GET api/<FeedbacksController>/5
        [HttpGet("{id}")]
        public ActionResult<Feedback> GetById(int id)
        {
            if (feedbacksService.GetById(id) != null)
                return feedbacksService.GetById(id);
            return NotFound();
        }

        // POST api/<FeedbacksController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Feedback feedback)
        {
            if (DataContextManager.DataContext.feedbacks == null)
                DataContextManager.DataContext.feedbacks = new List<Feedback>();
            if (feedbacksService.Add(feedback))
                return Ok(true);
            return NotFound();
        }

        // PUT api/<FeedbacksController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Feedback feedback)
        {
            if (feedbacksService.Update(id, feedback))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<FeedbacksController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (feedbacksService.Delete(id))
                return Ok(true);
            return NotFound();
        }
        public FeedbacksController()
        {
            if (feedbacksService == null)
                feedbacksService = new FeedbacksService();
        }
    }
}
