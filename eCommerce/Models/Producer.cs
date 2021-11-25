using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Producer
    {
        [Key]
        public int ID { get; set; }
        public string ProfilePictureURL { get; set; }
        public string Fullname { get; set; }
        public string Bio { get; set; }


        // Database 
        public List<Movie> Movies { get; set; }


    }
}
