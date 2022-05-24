using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepositoty _categoryRepository;
        private readonly AppDbContext _appDbContext;

        public AdminController(ICandyRepository candyRepository, ICategoryRepositoty categoryRepository, AppDbContext appDbContext)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
            _appDbContext = appDbContext;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult CandyList()
        {
            var candies = _candyRepository.GetAllCandy.OrderBy(c => c.CandyId);

            return View(candies);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult EditCandy(int id)
        {
            var candy = _candyRepository.GetCandyById(id);

            if(candy != null)
            {
                return View(new CandyCategoryViewModel
                {
                    Candy = candy,
                    Category = _categoryRepository.GetAllCategories
                }); ;
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult EditCandy_(Candy candy)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Entry(candy).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                return RedirectToAction("CandyList");
            }
            return View(candy);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCandy(int id)
        {
            var candy = _candyRepository.GetCandyById(id);

            if(candy != null)
            {
                return View(candy);
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult DeleteCandy_(Candy candy)
        {
            _appDbContext.Remove(candy);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult CreateCandy()
        {
            return View(new CandyCategoryViewModel 
            {
                Category = _categoryRepository.GetAllCategories
            
            });
        }


        [HttpPost]
        public IActionResult CreateCandy_(Candy candy)
        {
            _appDbContext.Add(candy);
            _appDbContext.SaveChanges();

            return RedirectToAction("CandyList");
        }
    }
}
