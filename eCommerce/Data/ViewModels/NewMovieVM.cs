using eCommerce.Data;
using eCommerce.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class NewMovieVM
    { 
        [Key]  
        public int ID { get; set; }
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Movie Name is Required")]
        public string Name { get; set; }
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }
        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is Required")]
        public string ImageURL { get; set; }
        [Display(Name = "Movie start date")]
        [Required(ErrorMessage = "Start date is Required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie end date")]
        [Required(ErrorMessage = "End date is Required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Movie Category is Required")]
        public MovieCategory MovieCategory { get; set; }


        //Database
        [Display(Name = "Select Actor(s)")]
        [Required(ErrorMessage = "Movie Actor(s) is Required")]
        public List<int> ActorIDs { get; set; }

        //Relation to Cinema
        [Display(Name = "Select a Cinema")]
        [Required(ErrorMessage = "Movie Cinema is Required")]
        public int CinemaID { get; set; } // Foreign Key

        //Relation to Producer
        [Display(Name = "Select a Producer")]
        [Required(ErrorMessage = "Movie Producer is Required")]
        public int ProducerID { get; set; }
        
    }
}
