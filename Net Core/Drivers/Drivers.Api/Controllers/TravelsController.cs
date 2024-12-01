using Drivers.Core.Entities;
using Drivers.Core.Iservice;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drivers.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        readonly IService<TravelEntity> _travelService;
        public TravelsController(IService<TravelEntity> travelService)
        {
            _travelService = travelService;
        }
        // GET: api/<DriveresController>
        [HttpGet]
        public ActionResult<List<TravelEntity>> Get()
        {
            List<TravelEntity> result = _travelService.GetList();
            if (result == null) { return NotFound(); }
            return (result);
        }

        // GET api/<DriveresController>/5
        [HttpGet("GetById{id}")]
        public ActionResult<TravelEntity> GetById(int id)
        {
            if (id < 0) { return BadRequest(); }
            TravelEntity result = _travelService.GetById(id);
            if (result == null) { return NotFound(); }
            return (result);
        }
        // POST api/<DriveresController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] TravelEntity travel)
        {
            var result = _travelService.Add(travel);
            if (!result)
            {
                return BadRequest(false);
            }
            else
                return true;
        }

        // PUT api/<DriveresController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] TravelEntity travel)
        {
            if (_travelService.Update(id, travel))
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<DriveresController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (_travelService.Delete(id))
                return Ok(true);
            return NotFound();
        }
    }
}
