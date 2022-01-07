using eCommerce.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Producer: IEntityBase
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is Required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is not Valid")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should be in between 3 to 50 characters")]
        public string FullName { get; set; }
        [Display(Name = "Bio ")]
        [Required(ErrorMessage = "Bio is not Given")]
        public string Bio { get; set; }


        // Database 
        public List<Movie> Movies { get; set; }


    }
}
