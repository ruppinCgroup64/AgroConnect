using AgroConnect_server.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroConnect_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            Orders o = new Orders();
            return o.Read();
        }

        // GET api/<OrdersController>/5
        [HttpGet("/orders/{ConsumerId}")]
        public IEnumerable<Orders> GetByConsumerId(int ConsumerId)
        {
            Orders o = new Orders();
            return o.ReadByConsumerId(ConsumerId);
        }

        [HttpGet("/orderDetails/{OrderInPointId}")]
        public Orders GetOrderDetailsByOrderInPointId(int OrderInPointId)
        {
            Orders o = new Orders();
            return o.ReadDetailsByOrderInPointId(OrderInPointId);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public int Post([FromBody] Orders o)
        {
            return o.Insert();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public Orders Put(int id, [FromBody] Orders o)
        {
            return o.Update();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
