using Stocks_Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_task.core
{
    public interface ITypeHubClient
    {
        Task BroadCastMessage(Stock stock);
    }
}
