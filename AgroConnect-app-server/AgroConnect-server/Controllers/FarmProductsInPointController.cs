using AgroConnect_server.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroConnect_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmProductsInPointController : ControllerBase
    {
        // GET: api/<SalePointsController>
        [HttpGet("{id}")]
        public IEnumerable<FarmProductsInPoint> GetById(int id)
        {
            FarmProductsInPoint pip = new FarmProductsInPoint();
            return pip.ReadById(id);
        }

        // POST api/<FarmProductsInPointController>
        [HttpPost]
        public ActionResult Post([FromBody] List<FarmProductsInPoint> productsList)
        {
            var addedProducts = FarmProductsInPoint.InsertProducts(productsList);
            if (addedProducts.Any())
            {
                return Ok(addedProducts);
            }
            else
            {
                return BadRequest("No products were added.");
            }
        }


        // PUT api/<SalePointsController>/5
        [HttpPut("{id}")]
        public FarmProductsInPoint Put([FromBody] FarmProductsInPoint pip)
        {
            return pip.Update();
        }

    }


}
