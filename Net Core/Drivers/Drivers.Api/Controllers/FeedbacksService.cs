using Drivers.Core.Entities;
using Drivers.Core.Iservice;
using Drivers.Service;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drivers.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksService : ControllerBase
    {
        readonly IService<FeedbackEntity> _feedbacksService;
        public FeedbacksService(IService<FeedbackEntity> passengerService)
        {
            _feedbacksService = passengerService;
        }
        // GET: api/<DriveresController>
        [HttpGet]
        public ActionResult<List<FeedbackEntity>> Get()
        {
            List<FeedbackEntity> result = _feedbacksService.GetList();
            if (result == null) { return NotFound(); }
            return (result);
        }

        // GET api/<DriveresController>/5
        [HttpGet("GetById{id}")]
        public ActionResult<FeedbackEntity> GetById(int id)
        {
            if (id < 0) { return BadRequest(); }
            FeedbackEntity result = _feedbacksService.GetById(id);
            if (result == null) { return NotFound(); }
            return (result);
        }
        // POST api/<DriveresController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] FeedbackEntity feedback)
        {
            var result = _feedbacksService.Add(feedback);
            if (!result)
            {
                return BadRequest(false);
            }
            else
                return true;
        }

        // PUT api/<DriveresController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] FeedbackEntity feedback)
        {
            if (_feedbacksService.Update(id, feedback))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<DriveresController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (_feedbacksService.Delete(id))
                return Ok(true);
            return NotFound();
        }
    }
}
