using AgroConnect_server.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroConnect_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePointsController : ControllerBase
    {
        // GET: api/<SalePointsController>
        [HttpGet]
        public IEnumerable<SalePoints> Get()
        {
            SalePoints s = new SalePoints();
            return s.Read();
        }

        // GET api/<SalePointsController>/5
        [HttpGet("{id}")]
        public SalePoints GetById(int id)
        {
            SalePoints s = new SalePoints();
            return s.ReadById(id);
        }

        // POST api/<SalePointsController>
        [HttpPost]
        public int Post([FromBody] SalePoints s)
        {
            return s.Insert();
        }

        // PUT api/<SalePointsController>/5
        [HttpPut("{id}")]
        public SalePoints Put([FromBody] SalePoints s)
        {
            return s.Update();
        }

        // DELETE api/<SalePointsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
