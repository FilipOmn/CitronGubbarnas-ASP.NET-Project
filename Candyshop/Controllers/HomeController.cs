using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Candyshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandyRepository _candyRepository;

        public HomeController(ICandyRepository candyRepository)
        {

            _candyRepository = candyRepository;
        }
        public IActionResult Index()
        {
            var date = DateTime.Now;
            var homeViewModel = new HomeViewModel
            {
                CandyOnSale = _candyRepository.GetCandyOnSale.Where(c => c.AmountInStock > 0 && c.IsInStock == true && c.SalePercentage > 1 
                                && c.IsOnSale == true && c.SaleStartDate <= date && c.SaleEndDate >= date)
            };

            return View(homeViewModel);
        }
    }
}
