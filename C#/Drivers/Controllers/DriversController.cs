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
        readonly DriversService _driverSerice;
        public DriversController(DriversService driversService)
        {
            _driverSerice = driversService;
        }
        //private static DriversService driversService;
        // GET: api/<DriveresController>
        [HttpGet]
        public ActionResult<List<Driver>> Get()
        {
            List<Driver> result = _driverSerice.GetList();
            if (result == null) { return NotFound(); }
            return (result);
        }

        // GET api/<DriveresController>/5
        [HttpGet("GetById{id}")]
        public ActionResult<Driver> GetById(int id)
        {
            if (id < 0) { return BadRequest(); }
            Driver result = _driverSerice.GetById(id);
            if (result == null) { return NotFound(); }
            return (result);
            //if (id < 0)
            //    return BadRequest();
            //if (driversService.GetById(id) != null)
            //    return driversService.GetById(id);
            //return NotFound();
        }
        // POST api/<DriveresController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Driver driver)
        {
            var result = _driverSerice.Add(driver);
            if (!result)
            {
                return BadRequest(false);
            }
            else
                return true;
        }
        //public ActionResult<bool> Post([FromBody] Driver driver)
        //{
        //    if (!isValid(driver))
        //        return BadRequest();
        //    if (DataContextManager.DataContext.drivers == null)
        //        DataContextManager.DataContext.drivers = new List<Driver>();
        //    if (driversService.Add(driver))
        //        return Ok(true);
        //    return NotFound();
        //}

        // PUT api/<DriveresController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Driver driver)
        {
            if(!isValid(driver))
                return BadRequest();
            if (_driverSerice.Update(id, driver))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<DriveresController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (_driverSerice.Delete(id))
                return Ok(true);
            return NotFound();
        }

        private bool isValid(Driver driver)
        {
           return Validation.IsValidIsraeliID(driver.DriverTz);
        }
    }
}
