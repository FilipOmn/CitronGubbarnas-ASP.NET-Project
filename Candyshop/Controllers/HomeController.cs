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
        private readonly AppDbContext _appDbContext;
        public HomeController(ICandyRepository candyRepository, AppDbContext appDbContext)
        {

            _candyRepository = candyRepository;
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var date = DateTime.Now;
            var candiesGoingOffSale = _candyRepository.GetAllCandy.Where(c => c.SaleStartDate > date || c.SaleEndDate < date);
            var candiesGoingOnSale = _candyRepository.GetAllCandy.Where(c => c.SaleStartDate <= date && c.SaleEndDate >= date);
           
            foreach (var item in candiesGoingOffSale)
            {
                item.IsOnSale = false;
            }
            _appDbContext.SaveChanges();

            foreach (var item in candiesGoingOnSale)
            {
                item.IsOnSale = true;
            }
            _appDbContext.SaveChanges();
            

            var homeViewModel = new HomeViewModel
            {
                CandyOnSale = _candyRepository.GetCandyOnSale.Where(c => c.AmountInStock > 0 && c.IsInStock == true && c.SalePercentage > 1 
                                && c.IsOnSale == true && c.SaleStartDate <= date && c.SaleEndDate >= date),

                NewCandy = _candyRepository.GetNewCandy.Where(c => c.IsNew == true)

            };

           


            return View(homeViewModel);
        }
    }
}
