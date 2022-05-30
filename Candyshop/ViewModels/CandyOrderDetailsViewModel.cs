using Candyshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.ViewModels
{
    public class CandyOrderDetailsViewModel
    {
        public IEnumerable<Candy> Candies { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
