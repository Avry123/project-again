using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_asp.Data;
using project_asp.Data.Services;
using project_asp.Models;

namespace project_asp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {

            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
        {
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("Not Found");
            }
            return View(cinemaDetails);
        }

        //Get:Update cinema

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("Not Found");
            }
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,[Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
           
            await _service.UpdateAsync(id,cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get:Delete

       

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("Not Found");
            }
            return View(cinemaDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("Not found");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
