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
        public  ICandyRepository _candyRepository;
        public  ICategoryRepositoty _categoryRepository;
        public  ICandyRatingRepository _candyRatingRepository;
        public  AppDbContext _appDbContext;

        public CandyController(ICandyRepository candyRepository, ICategoryRepositoty categoryRepository, AppDbContext appDbContext, ICandyRatingRepository candyRatingRepository)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
            _appDbContext = appDbContext;
            _candyRatingRepository = candyRatingRepository;
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
            var candyViewModel = new CandyViewModel();
            candyViewModel.Candy = _candyRepository.GetCandyById(id);
            candyViewModel.CandyRatings = _candyRatingRepository.GetAllRatingsForSpecificCandy(id);
            candyViewModel.RatingSum = CandyRatingRepository.GetAverageRating(candyViewModel.CandyRatings);  //_candyRatingRepository.GetAverageRating(candyViewModel.CandyRatings);
            if (candyViewModel.Candy == null)
            {
                return NotFound();
            }
                
            return View(candyViewModel);
        }
        public IActionResult RatingSuccess(CandyViewModel candyView, int candyId)
        {
            _candyRatingRepository.AddRatingToCandy(candyId, candyView.CandyRating);
            CandyViewModel viewModel = new CandyViewModel();
            viewModel.Candy = _candyRepository.GetCandyById(candyId);
            return View(viewModel);
        }
    }
}
