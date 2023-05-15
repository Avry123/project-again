using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_asp.Data;
using project_asp.Data.Services;

namespace project_asp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {

            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        //Get: Movies/Details/1

        /*   public async Task<IActionResult> Details(int id)
           {
               var movieDetail = await _service.GetByIdAsync(id);
               return View(movieDetail);
           } */

        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id, m => m.Cinema);
            return View(movieDetail);
        }

    }
}
