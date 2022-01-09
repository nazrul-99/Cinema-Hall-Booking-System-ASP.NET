using eCommerce.Data;
using eCommerce.Data.Services.eTickets.Data.Services;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        //GET: Movies/Details/ID
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "ID", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "ID", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ID", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "ID", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "ID", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ID", "FullName");

                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
