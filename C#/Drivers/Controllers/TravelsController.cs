using Drivers.Services;
using Microsoft.AspNetCore.Mvc;
using Drivers.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private static TravelsService travelsService;
        // GET: api/<TravelדController>
        [HttpGet]
        public ActionResult<List<Travel>> Get()
        {
           return  DataContextManager.DataContext.travels;

        }
         
        // GET api/<TravelדController>/5
        [HttpGet("{id}")]
        public ActionResult<Travel> GetById(int id)
        {
            if (travelsService.GetById(id) != null)
                return travelsService.GetById(id);
            return NotFound();

        }

        // POST api/<TravelדController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Travel travel)
        {
            if (DataContextManager.DataContext.travels == null)
                DataContextManager.DataContext.travels = new List<Travel>();
            if (travelsService.Add(travel))
                return Ok(true);
            return NotFound();
        }

        // PUT api/<TravelדController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Travel travel)
        {
            if (travelsService.Update(id, travel))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<TravelדController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (travelsService.Delete(id))
                return Ok(true);
            return NotFound();
        }
        public TravelsController()
        {
            if (travelsService == null)
                travelsService = new TravelsService();
        }
    }
}
