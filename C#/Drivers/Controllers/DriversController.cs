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
            return DataContextManager.DataContext.drivers;
        }

        // GET api/<DriveresController>/5
        [HttpGet("{id}")]
        public ActionResult<Driver> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            if (driversService.GetById(id) != null)
                return driversService.GetById(id);
            return NotFound();
        }

        // POST api/<DriveresController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Driver driver)
        {
            if (!isValid(driver))
                return BadRequest();
            if (DataContextManager.DataContext.drivers == null)
                DataContextManager.DataContext.drivers = new List<Driver>();
            if (driversService.Add(driver))
                return Ok(true);
            return NotFound();
        }

        // PUT api/<DriveresController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Driver driver)
        {
            if(!isValid(driver))
                return BadRequest();
            if (driversService.Update(id, driver))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<DriveresController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (driversService.Delete(id))
                return Ok(true);
            return NotFound();
        }
        public DriversController()
        {

            if (driversService == null)
                driversService = new DriversService();
        }
        private bool isValid(Driver driver)
        {
           return Validation.IsValidIsraeliID(driver.DriverTz);
        }
    }
}
