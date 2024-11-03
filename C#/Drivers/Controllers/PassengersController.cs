using Drivers.Services;
using Microsoft.AspNetCore.Mvc;
using Drivers.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private static PassengersService passengersService;
        // GET: api/<PassengersController>
        [HttpGet]
        public ActionResult<List<Passenger>> Get()
        {
            if (passengersService.passengers != null)
                return passengersService.passengers;
            return NotFound();

        }

        // GET api/<PassengersController>/5
        [HttpGet("{id}")]
        public ActionResult<Passenger> Get(int id)
        {
            if (passengersService.GetPassengerById(id) != null)
                return passengersService.GetPassengerById(id);
            return NotFound();
        }

        // POST api/<PassengersController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Passenger passenger)
        {
            if (passengersService.PostPassenger(passenger))
                return Ok(true);
            return NotFound();
        }

        // PUT api/<PassengersController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Passenger passenger)
        {
            if (passengersService.PutPassenger(id, passenger))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<PassengersController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (passengersService.DeletePassenger(id))
                return Ok(true);
            return NotFound();
        }
        public PassengersController()
        {
            if (passengersService == null)
                passengersService = new PassengersService();
        }
    }
}
