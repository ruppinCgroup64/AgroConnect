using AgroConnect_server.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroConnect_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductsController>/farmer/5
        [HttpGet("farmer/{farmId}")]
        public IEnumerable<Products> GetByFarmerId(int farmId)
        {
            Products p = new Products();
            return p.ReadByFarm(farmId);
        }

        // GET api/<ProductsController>/consumer/5
        [HttpGet("consumer/{consumerId}")]
        public IEnumerable<Products> GetByConsumerId(int consumerId)
        {
            Products p = new Products();
            return p.ReadByConsumer(consumerId);
        }

        // GET api/<ProductsController>/consumer/5
        [HttpGet("order/{orderId}")]
        public IEnumerable<Products> GetByConsumerAndOrderId(int orderId, [FromQuery] int consumerId)
        {
            Products p = new Products();
            return p.ReadByConsumerAndOrder(orderId, consumerId);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public int Post([FromBody] Products p)
        {
            return p.Insert();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
