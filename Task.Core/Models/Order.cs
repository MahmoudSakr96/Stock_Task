using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks_Task.DAL.Models
{
    public class Order
    {
        public int Stockid { get; set; }
        public string StockName { get; set; }

        [Required]
        public Double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Double? Commission { get; set; }

        public virtual Person Person { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
        public virtual Broker Broker { get; set; }




    }
}
