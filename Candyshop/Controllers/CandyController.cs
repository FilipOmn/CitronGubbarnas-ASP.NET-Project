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

        public CandyController(ICandyRepository candyRepository, ICategoryRepositoty categoryRepository)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
             
            IEnumerable<Candy> candies;
            string currentCategory;
            
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
                CurrentCategory = currentCategory });
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
