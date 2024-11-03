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
            if (travelsService.travels != null)
                return travelsService.travels;
            return NotFound();

        }

        // GET api/<TravelדController>/5
        [HttpGet("{id}")]
        public ActionResult<Travel> Get(int id)
        {
            if (travelsService.GetTravelById(id) != null)
                return travelsService.GetTravelById(id);
            return NotFound();

        }

        // POST api/<TravelדController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Travel travel)
        {
            if (travelsService.PostTravel(travel))
                return Ok(true);
            return NotFound();
        }

        // PUT api/<TravelדController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Travel travel)
        {
            if (travelsService.PutTravel(id, travel))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<TravelדController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (travelsService.DeleteTravel(id))
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
