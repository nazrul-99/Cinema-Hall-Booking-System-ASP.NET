using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ID { get; set; }

        public Movie Movie { get; set; }
        public int Amount { get; set; }


        // This is used for the shopping cart model
        public string ShoppingCartID { get; set; }
    }
}
