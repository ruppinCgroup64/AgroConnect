using AgroConnect_server.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroConnect_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumersController : ControllerBase
    {
        // GET: api/<ConsumersController>
        [HttpGet]
        public IEnumerable<Consumers> Get()
        {
            Consumers c = new Consumers();
            return c.Read();
        }

        // GET api/<ConsumersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConsumersController>
        [HttpPost()]
        public Consumers Post([FromBody] Consumers c)
        {
            Consumers res = c.Insert();
            return res; 
        }

        [HttpPost]
        [Route("Login")]
        public Consumers Login([FromBody] Consumers c)
        {
            c.DateOfBirth = "01.01.2024"; //sp expects DOB value
            return c.LoginConsumer();
        }

        // PUT api/<ConsumersController>/5
        [HttpPut]
        public Consumers Put([FromBody] Consumers c)
        {
            return c.Update();
        }

        [HttpPut]
        [Route("isActive")]
        public int UpdateActive([FromBody] Consumers c)
        {
            return c.UpdateIsActive();
        }

        // DELETE api/<ConsumersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Consumers c = new Consumers();
                c.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
