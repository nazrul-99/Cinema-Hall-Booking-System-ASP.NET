using eCommerce.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCatagory MovieCatagory { get; set; }


        //Database
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Relation to Cinema
        public int CinemaID { get; set; } // Foreign Key
        [ForeignKey("CinemaID")]
        public Cinema Cinema { get; set; }

        //Relation to Producer
        public int PrducerID { get; set; }
        [ForeignKey("PrducerID")]
        public Producer Prducer { get; set; }
    }
}
