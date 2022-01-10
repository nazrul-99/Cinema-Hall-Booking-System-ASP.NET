using eCommerce.Data.Base;
using eCommerce.Data.Services.eTickets.Data.Services;
using eCommerce.Data.ViewModels;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Description = movie.Description,
                Price = movie.Price,
                ImageURL = movie.ImageURL,
                CinemaID = movie.CinemaID,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                MovieCategory = movie.MovieCategory,
                ProducerID = movie.ProducerID
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in movie.ActorIDs)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieID = newMovie.ID,
                    ActorID = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.ID == id);

            return movieDetails;
        }


        public async Task<NewMovieDropdownVM> GetNewMovieDropdownValues()
        {
            var response = new NewMovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM movie)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.ID == movie.ID);

            if (dbMovie != null)
            {
                dbMovie.Name = movie.Name;
                dbMovie.Description = movie.Description;
                dbMovie.Price = movie.Price;
                dbMovie.ImageURL = movie.ImageURL;
                dbMovie.CinemaID = movie.CinemaID;
                dbMovie.StartDate = movie.StartDate;
                dbMovie.EndDate = movie.EndDate;
                dbMovie.MovieCategory = movie.MovieCategory;
                dbMovie.ProducerID = movie.ProducerID;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieID == movie.ID).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorID in movie.ActorIDs)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieID = movie.ID,
                    ActorID = actorID
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}