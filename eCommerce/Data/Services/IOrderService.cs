using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userID, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userID, string userRole);
    }
}
