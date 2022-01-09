using eCommerce.Data.Base;
using eCommerce.Data.ViewModels;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data.Services
{
    namespace eTickets.Data.Services
    {
        public interface IMovieService : IEntityBaseRepository<Movie>
        {
            Task<Movie> GetMovieByIdAsync(int id);
            Task<NewMovieDropdownVM> GetNewMovieDropdownValues();
            Task AddNewMovieAsync(NewMovieVM data);
        }
    }
}
