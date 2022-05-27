using Candyshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _appDbContext;

        public OrderController(IOrderRepository orderRepository , ShoppingCart shoppingCart, AppDbContext appDbContext)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _appDbContext = appDbContext;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }
            if (ModelState.IsValid)
            {
                foreach(var item in _shoppingCart.ShoppingCartItems)
                {
                    if(item.Candy.AmountInStock < item.Amount)
                    {
                        return RedirectToAction("CheckoutFailed");
                    }

                    item.Candy.AmountInStock -= item.Amount;
                }
                _appDbContext.SaveChanges();

                _orderRepository.CreatOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for your order. Enjoy your candy";
            return View();
        }

        public IActionResult CheckoutFailed()
        {
            ViewBag.CheckoutFailedMessage = "There is not enought candy in stock to complete this order";
            return View();
        }
    }
}
