using eCommerce.Data.Cart;
using eCommerce.Data.Services.eTickets.Data.Services;
using eCommerce.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMovieService _moviesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _ordersService;


        public OrderController(IMovieService moviesService, ShoppingCart shoppingCart, IOrderService ordersService)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public IActionResult ShoppingCartSummary()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int iD)
        {
            var item = await _moviesService.GetMovieByIdAsync(iD);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCartSummary));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int iD)
        {
            var item = await _moviesService.GetMovieByIdAsync(iD);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCartSummary));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userID = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userID, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
