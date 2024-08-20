using AgroConnect_server.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroConnect_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<Object> Post([FromBody] Bids b)
        {
            int t = b.TenderNum;
            return b.Insert(t);
        }

        [HttpGet("{tenderID}")]
        public IEnumerable<Bids> Get(int tenderID)
        {
            Bids b = new Bids();
            return b.Read(tenderID);
        }

        [HttpDelete("{bidID}/{tenderID}")]
        public IEnumerable<Object> Delete(int bidID, int tenderID)
        {
            Bids b = new Bids();
            return b.Delete(bidID,tenderID);
        }
    }
}
