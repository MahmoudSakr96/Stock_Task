using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks_Task.DAL.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

    }
}
