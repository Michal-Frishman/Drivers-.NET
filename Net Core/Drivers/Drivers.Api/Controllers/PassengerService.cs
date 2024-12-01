using Drivers.Core.Entities;
using Drivers.Core.Iservice;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drivers.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PassengerService : ControllerBase
    {
        readonly IService<PassengerEntity> _passengerService;
        public PassengerService(IService<PassengerEntity> passengerService)
        {
            _passengerService = passengerService;
        }
        // GET: api/<DriveresController>
        [HttpGet]
        public ActionResult<List<PassengerEntity>> Get()
        {
            List<PassengerEntity> result = _passengerService.GetList();
            if (result == null) { return NotFound(); }
            return (result);
        }

        // GET api/<DriveresController>/5
        [HttpGet("GetById{id}")]
        public ActionResult<PassengerEntity> GetById(int id)
        {
            if (id < 0) { return BadRequest(); }
            PassengerEntity result = _passengerService.GetById(id);
            if (result == null) { return NotFound(); }
            return (result);
        }
        // POST api/<DriveresController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] PassengerEntity passenger)
        {
            var result = _passengerService.Add(passenger);
            if (!result)
            {
                return BadRequest(false);
            }
            else
                return true;
        }

        // PUT api/<DriveresController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] PassengerEntity driver)
        {

            if (_passengerService.Update(id, driver))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<DriveresController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (_passengerService.Delete(id))
                return Ok(true);
            return NotFound();
        }
    }
}
