using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepositoty _categoryRepository;
        private readonly AppDbContext _appDbContext;

        public CandyController(ICandyRepository candyRepository, ICategoryRepositoty categoryRepository, AppDbContext appDbContext)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
            _appDbContext = appDbContext;
        }

        public ViewResult List(string category)
        {
             
            IEnumerable<Candy> candies;
            string currentCategory;

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


            if (string.IsNullOrEmpty(category))
            {
                candies = _candyRepository.GetAllCandy.Where(c => c.AmountInStock > 0 && c.IsInStock == true);
                currentCategory ="All Candy";
            }
            else
            {
                candies = _candyRepository.GetAllCandy.Where(c => c.Category.CategoryName == category && c.AmountInStock > 0 && c.IsInStock == true);

                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new CandyListViewModel 
            {
                Candies = candies, 
                CurrentCategory = currentCategory 
            });
        }

        public IActionResult CandySearch(string search)
        {
            var candiesSearched = _candyRepository.GetAllCandy.Where(c => c.Name.ToLower().Contains($"{search}".ToLower())).ToList();
            ViewBag.Search = search;

            return View(candiesSearched);
        }

        [HttpGet]
        public IActionResult SearchAutoComplete()
        {
            var term = HttpContext.Request.Query["term"].ToString();
            var query = (from c in _candyRepository.GetAllCandy
                         where c.Name.ToLower().Contains(term.ToLower())
                         select new
                         {
                             label = c.Name,
                             category = c.Category.CategoryName
                         }).ToList();
            return Ok(query);
        }

        public IActionResult Details(int id)
        {
            var candy = _candyRepository.GetCandyById(id);
            if(candy == null)
            {
                return NotFound();
            }
                

            return View(candy);

            
        }
    }
}
