using AgroConnect_server.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroConnect_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersInPointController : ControllerBase
    {
        // GET: api/<OrdersInPoint_Controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersInPoint_Controller>/5
        [HttpGet("ordersInPoint/{salePointId}")]
        public IEnumerable<OrdersInPoint> GetBySalePointId(int salePointId)
        {
            OrdersInPoint oip = new OrdersInPoint();
            return oip.ReadBySalePointId(salePointId);
        }

        [HttpGet("orderInPointDetails/{orderId}")]
        public IEnumerable<OrdersInPoint> GetOrderInPointDetailsByOrderId(int orderId)
        {
            OrdersInPoint oip = new OrdersInPoint();
            return oip.ReadDetailsByOrderId(orderId);
        }

        // POST api/<OrdersInPoint_Controller>
        [HttpPost]
        public ActionResult Post([FromBody] List<OrdersInPoint> productsInPointOrderList)
        {
            int lastOrderNum = OrdersInPoint.InsertOrderProductsInPoint(productsInPointOrderList);
            if (lastOrderNum > 0) // a positive orderNum indicates success
            {
                return Ok(new { OrderNum = lastOrderNum });
            }
            else
            {
                return BadRequest("No products were added.");
            }
        }

        // PUT api/<OrdersInPoint_Controller>/5
        [HttpPut("{id}")]
        public OrdersInPoint Put(int id, [FromBody] OrdersInPoint oip)
        {
            oip.Id = id;
            return oip.Update();
        }


        // DELETE api/<OrdersInPoint_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
