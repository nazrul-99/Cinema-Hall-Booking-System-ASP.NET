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

        public OrderController(IMovieService moviesService, ShoppingCart shoppingCart)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
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
    }
}
