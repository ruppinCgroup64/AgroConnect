using AgroConnect_server.BL;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroConnect_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        // GET: api/<TendersController>
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            Tenders t = new Tenders();
            return t.Read();
        }

        // GET api/<TendersController>
        [HttpGet("{consumerId}")]
        public IEnumerable<Object> GetByConsumerBids(int consumerId)
        {
            Tenders t = new Tenders();
            return t.ReadTendersByConsumerBids(consumerId);
        }

        // GET api/<TendersController>
        [HttpGet("farm/{farmID}")]
        public IEnumerable<Object> GetByFarm(int farmID)
        {
            Tenders t = new Tenders();
            return t.ReadTendersByFarm(farmID);
        }

        [HttpGet("BidsDetails/{tenderID}")]
        public IEnumerable<Object> GetTenderBidsDetails(int tenderID)
        {
            return Tenders.ReadTenderBidsDetails(tenderID);
        }

        [HttpGet("Win/{consumerId}")]
        public IEnumerable<Object> GetWin(int consumerId)
        {
            Tenders t = new Tenders();
            return t.ReadTendersConsumerWin(consumerId);
        }

        [HttpGet("Win/ShowInOrders/{consumerId}")]
        public IEnumerable<Object> GetWinShowInOrders(int consumerId)
        {
            Tenders t = new Tenders();
            return t.ReadTendersConsumerWinShowInOrders(consumerId);
        }

        [HttpGet("avgProduct/{productID}")]
        public float GetProductAvgPrice(int productID)
        {
            Tenders t = new Tenders();
            return t.ReadAvgProductPrice(productID);
        }
        // POST api/<TendersController>
        [HttpPost]
        public Tenders Post([FromBody] Tenders t)
        {
            Tenders res = t.Insert();
            return res;
        }

        // PUT api/<TendersController>
        [HttpPut("{id}")]
        public Tenders Put(int id,[FromBody] Tenders t)
        {
            return t.Update();

        }

        //update only activity (deleted) 1- active, 0-not active
        [HttpPut("{tenderID}/{active}")]
        public int Put(int tenderID, bool active)
        {
            Tenders t = new Tenders();
            return t.UpdateActivity(tenderID, active);
        }

    }
}
