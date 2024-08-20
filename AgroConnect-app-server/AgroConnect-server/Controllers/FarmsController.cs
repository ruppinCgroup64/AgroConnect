using AgroConnect_server.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroConnect_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        // GET: api/<FarmsController>
        [HttpGet]
        public IEnumerable<Farms> Get()
        {
            Farms f = new Farms();
            return f.Read();
        }

        // GET api/<FarmsController>/5
        [HttpGet("farmer/{farmerId}")]
        public IEnumerable<Farms> Get(int farmerId)
        {
            Farms f = new Farms();
            return f.ReadById(farmerId);
        }

        // GET api/<FarmsController>/5
        [HttpGet("order/{orderId}")]
        public Farms GetByConsumerAndOrderId(int orderId, [FromQuery] int consumerId)
        {
            Farms f = new Farms();
            return f.ReadByConsumerAndOrder(orderId, consumerId);
        }

        // GET api/<FarmsController>/5
        [HttpGet("salePoint/{salePointId}")]
        public Farms GetBySalePointId(int salePointId)
        {
            Farms f = new Farms();
            return f.ReadSalePointId(salePointId);
        }

        // POST api/<FarmsController>
        [HttpPost]
        public Farms Post([FromBody] Farms f)
        {
            return f.Insert();
        }

        // PUT api/<FarmsController>/5
        [HttpPut]
        public Farms Put([FromBody] Farms f)
        {
            return f.Update();
        }

        // DELETE api/<ConsumersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Farms F = new Farms();
                F.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
