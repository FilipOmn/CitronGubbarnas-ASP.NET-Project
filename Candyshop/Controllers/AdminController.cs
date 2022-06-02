using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> OrderLogAsync(int currency)
        {
            var client = new RestClient("https://api.apilayer.com/exchangerates_data/latest?symbols=EUR,USD,GBP,SEK&base=SEK");

            var request = new RestRequest()
                .AddHeader("apikey", "j6oL2F9e9MkRUeNLRydtSNMEw6yatyqW");

            var response = await client.GetAsync(request);

            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);

            if(currency == 1)
            {
                ViewBag.CurrencyExchange = jsonResponse.rates.EUR;
                ViewBag.CurrencySymbol = "€";

                return View(new OrderOrderDetailsViewModel
                {
                    Orders = _appDbContext.Orders,
                    OrderDetails = _appDbContext.OrderDetails
                });
            }
            if (currency == 2)
            {
                ViewBag.CurrencyExchange = jsonResponse.rates.USD;
                ViewBag.CurrencySymbol = "$";

                return View(new OrderOrderDetailsViewModel
                {
                    Orders = _appDbContext.Orders,
                    OrderDetails = _appDbContext.OrderDetails
                });
            }
            if (currency == 3)
            {
                ViewBag.CurrencyExchange = jsonResponse.rates.GBP;
                ViewBag.CurrencySymbol = "£";

                return View(new OrderOrderDetailsViewModel
                {
                    Orders = _appDbContext.Orders,
                    OrderDetails = _appDbContext.OrderDetails
                });
            }
            if (currency == 4)
            {
                ViewBag.CurrencyExchange = jsonResponse.rates.SEK;
                ViewBag.CurrencySymbol = "Kr";

                return View(new OrderOrderDetailsViewModel
                {
                    Orders = _appDbContext.Orders,
                    OrderDetails = _appDbContext.OrderDetails
                });
            }

            ViewBag.CurrencyExchange = 1m;
            ViewBag.CurrencySymbol = "Kr";

            return View(new OrderOrderDetailsViewModel 
            {
                Orders = _appDbContext.Orders,
                OrderDetails = _appDbContext.OrderDetails
            });
        }


        [Authorize(Roles = "Admin")]
        public IActionResult OrderLogDetails(int id)
        {
            var OrderDetails = _appDbContext.OrderDetails.Include("Candy").Where(o => o.OrderId == id);

            return View(new CandyOrderDetailsViewModel
            {
                Candies = _candyRepository.GetAllCandy,
                OrderDetails = OrderDetails
            });
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
