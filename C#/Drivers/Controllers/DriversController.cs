using Drivers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Drivers.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private static DriversService driversService;
        // GET: api/<DriveresController>
        [HttpGet]
        public ActionResult<List<Driver>> Get()
        {
            if (driversService.drivers != null)
                return driversService.drivers;
            return NotFound();
        }

        // GET api/<DriveresController>/5
        [HttpGet("{id}")]
        public ActionResult<Driver> Get(int id)
        {
            if (driversService.GetDriverById(id) != null)
                return driversService.GetDriverById(id);
            return NotFound();
        }

        // POST api/<DriveresController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Driver driver)
        {
            if (driversService.PostDriver(driver))
                return Ok(true);
            return NotFound();
        }

        // PUT api/<DriveresController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Driver driver)
        {
            if (driversService.PutDriver(id, driver))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<DriveresController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (driversService.DeleteDriver(id))
                return Ok(true);
            return NotFound();
        }
        public DriversController()
        {
            if (driversService == null)
                driversService = new DriversService();
        }
    }
}
