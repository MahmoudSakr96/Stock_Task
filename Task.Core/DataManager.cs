using Stocks_Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_task.Core
{
    public class DataManager
    {
        /// <summary>
        /// Seed data with random price values
        /// </summary>
        /// <returns>return List of Stock with random price values</returns>
        public static List<Stock> GetData()
        {
            var r = new Random();
            return new List<Stock>
            {
                new Stock{ID = 1,  Name = "Vianet",       Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 2,  Name = "Agritek",      Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 3,  Name = "Akamai",       Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 4,  Name = "Baidu",        Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 5,  Name = "Blinkx",       Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 6,  Name = "Blucora",      Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 7,  Name = "Boingo",       Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 8,  Name = "Brainybrawn",  Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 9,  Name = "Carbonite",    Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 10, Name = "China Finance",Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 11, Name = "ChinaCache",   Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 12, Name = "ADR",          Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 13, Name = "ChitrChatr",   Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 14, Name = "Cnova",        Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 15, Name = "Cogent",       Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 16, Name = "Crexendo",     Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 17, Name = "CrowdGather",  Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 18, Name = "EarthLink",    Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 19, Name = "Eastern",      Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 20, Name = "ENDEXX",       Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 21, Name = "Envestnet",    Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 22, Name = "Epazz",        Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 23, Name = "FlashZero",    Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 24, Name = "Genesis",      Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 25, Name = "InterNAP",     Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 26, Name = "MeetMe",       Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 27, Name = "Netease",      Price =   new List<int> { r.Next(1, 100) }   },
                new Stock{ID = 28, Name = "Qihoo",        Price =   new List<int> { r.Next(1, 100) }   }

            };
        }
        /// <summary>
        /// Seed Random values (quantity ,Person ,Broker)
        /// </summary>
        /// <param name="data"></param>
        /// <returns>return Order data</returns>
        public static Order GetOrderData(Stock data)
        {
            var r = new Random();
            int random = r.Next(0, 3);
            int randomPerson = r.Next(0, 2);

            // seed tow person and one Broker 
            List<Person> person = new() { 
                new Person() { ID = 0, Name = "Mahmoud" },
                new Person() { ID = 1, Name = "Mohamed" } 
            };
            Broker broker = new Broker { ID=3, Name="Ali" };

            //check random id equal person or Broker 
            if (random == 0 || random == 1)
            {
                return new Order
                {
                    Stockid = data.ID,
                    StockName = data.Name,
                    Price = data.Price[0],
                    Quantity = r.Next(1, 100),
                    Commission = CalculateCommision(data.Price[0],false),
                    Person = new Person{ ID = person[random].ID, Name = person[random].Name },
                    Broker = null

                };

            }
            else
            {
                return new Order
                {
                    Stockid = data.ID,
                    StockName = data.Name,
                    Price = data.Price[0],
                    Quantity = r.Next(1, 100),
                    Commission = CalculateCommision(data.Price[0], true),
                    // random person
                    Person = new Person { ID = person[randomPerson].ID, Name = person[randomPerson].Name },
                    Broker = new Broker{ ID = broker.ID, Name = broker.Name },

                };

            }
        }

        /// <summary>
        /// return commission Based on order added to person or client
        /// </summary>
        /// <param name="price"> Integer Type</param>
        /// <param name="isAddedToBorker">Boolesn Type</param>
        /// <returns>When isAddedToBorker equal true return 1% from price else return 2% from price </returns>
        public static double CalculateCommision(int price , Boolean isAddedToBorker)
        {
            if(isAddedToBorker)
                return price * .01;
            else
                return price * .02;

        }
    }   
}
