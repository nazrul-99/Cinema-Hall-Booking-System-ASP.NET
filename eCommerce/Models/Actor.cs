using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Actor
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is Required")]
        public string ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "Full Name is not Valid")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should be in between 3 to 50 characters")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bio is not Given")]
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        // Database
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
