using eCommerce.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Cinema: IEntityBase   
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema Logo is Required")]
        public string Logo { get; set; }
        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is Required")]
        public string Name { get; set; }
        [Display(Name = "Cinema Description")]
        [Required(ErrorMessage = "Cinema Description is Required")]
        public string Description { get; set; }


        // Database 
        public List<Movie> Movies { get; set; }
    }
}
