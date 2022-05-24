using Candyshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.ViewModels
{
    public class CandyCategoryViewModel
    {
        public Candy Candy { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}
