using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Actor_Movie
    {
        public int MovieID { get; set; } // MovieID is the foreign key of the movie model
        public Movie Movie { get; set; }
        public int ActorID { get; set; } // ActorID is the foreign key of the actor model
        public Actor Actor { get; set; }

    }
}
