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
            return DataContextManager.DataContext.passengers;

        }

        // GET api/<PassengersController>/5
        [HttpGet("{id}")]
        public ActionResult<Passenger> GetById(int id)
        {
            if (passengersService.GetById(id) != null)
                return passengersService.GetById(id);
            return NotFound();
        }

        // POST api/<PassengersController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Passenger passenger)
        {
            if (DataContextManager.DataContext.passengers == null)
                DataContextManager.DataContext.passengers = new List<Passenger>();
            if (passengersService.Add(passenger))
                return Ok(true);
            return NotFound();
        }

        // PUT api/<PassengersController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Passenger passenger)
        {
            if (passengersService.Update(id, passenger))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<PassengersController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (passengersService.Delete(id))
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
