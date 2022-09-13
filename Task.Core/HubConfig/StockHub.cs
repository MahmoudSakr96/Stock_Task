using Microsoft.AspNetCore.SignalR;
using Stock_task.core;
using Stocks_Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_task.Core;


namespace Stock_task
{
    public class StockHub : Hub<ITypeHubClient>
    {
        private readonly IHubContext<StockHub> _hub;
        public StockHub(IHubContext<StockHub> hub)
        {
            _hub = hub;

        }

        public async Task broadcastStockdata(Stock data) =>
            await _hub.Clients.All.SendAsync("broadcastStockdata", DataManager.GetOrderData(data));


    }
}
