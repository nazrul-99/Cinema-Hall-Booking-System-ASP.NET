using eCommerce.Data.Base;
using eCommerce.Data.Services.eTickets.Data.Services;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        public MovieService(AppDbContext context) : base(context)
        {
        }
    }
}
