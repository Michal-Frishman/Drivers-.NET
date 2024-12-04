using Drivers.Core.Entities;
using Drivers.Core.Iservice;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drivers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        readonly IService<DriverEntity> _driverSerice;
        public DriversController(IService<DriverEntity> driversService)
        {
            _driverSerice = driversService;
        }
        // GET: api/<DriveresController>
        [HttpGet]
        public ActionResult<List<DriverEntity>> Get()
        {
            List<DriverEntity> result = _driverSerice.GetList();
            if (result == null) { return NotFound(); }
            return (result);
        }

        // GET api/<DriveresController>/5
        [HttpGet("GetById{id}")]
        public ActionResult<DriverEntity> GetById(int id)
        {
            if (id < 0) { return BadRequest(); }
            DriverEntity result = _driverSerice.GetById(id);
            if (result == null) { return NotFound(); }
            return (result);
        }
        // POST api/<DriveresController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] DriverEntity driver)
        {
            var result = _driverSerice.Add(driver);
            if (!result)
            {
                return BadRequest(false);
            }
            else
                return true;
        }

        // PUT api/<DriveresController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] DriverEntity driver)
        {
            //    if (!isValid(driver))
            //        return BadRequest();
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

        //private bool isValid(DriverEntity driver)
        //{
        //    return Validation.IsValidIsraeliID(driver.DriverTz);
        //}
    }
}
