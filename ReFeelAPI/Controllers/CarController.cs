using Microsoft.AspNetCore.Mvc;
using ReFeelAPI.Models.DTo;
using ReFeelCourtesy.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReFeelAPI.Controllers
{
    [Route("api/Car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public iLoggin _logger { get; }

        public CarController(iLoggin logger)
        {
            _logger = logger;
        }

        // GET: api/<ReFeelAPIController>
        [HttpGet]
        public IEnumerable<CarDTo> GetCars()
        {
            _logger.Log("Getting all cars", "");
            return new List<CarDTo>
            {
                new CarDTo{ Id = 1, Name="BMW" },
                new CarDTo{ Id = 2, Name="Citroen" },
            };
        }

        // GET api/<ReFeelAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReFeelAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReFeelAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReFeelAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
