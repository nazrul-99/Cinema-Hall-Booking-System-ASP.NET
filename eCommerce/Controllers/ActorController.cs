using eCommerce.Data;
using eCommerce.Data.Services;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _service;

        public ActorController(IActorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var actors = await _service.GetAll();
            return View(actors);
        }

        //Get request: Actor/Create 
        // As there is no data manupulation so we have not used the Task async
        public IActionResult Create()
        {
            return View();
        }

        //Creating an Actor Profile
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }
    }

}