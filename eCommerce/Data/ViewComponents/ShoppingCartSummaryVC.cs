using eCommerce.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data.ViewComponents
{
    public class ShoppingCartSummaryVC: ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummaryVC(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
