using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Stock_task.Core;

namespace Stock_task.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StockController : Controller
    {
        private readonly IHubContext<StockHub> _hub;
        public StockController(IHubContext<StockHub> hub)
        {
            _hub = hub;
            
        }
        // GET: StockController
        /// <summary>
        /// Sending random data to transferStockData
        /// </summary>
        /// <returns> return status code 200 with Massage 'Request complete'</returns>
        public ActionResult Get()
        {
            var timerManger = new TimeManger(() => _hub.Clients.All.SendAsync("transferStockData", DataManager.GetData()));
            return Ok(new {Massage = "Request complete"});
        }

    }
}
