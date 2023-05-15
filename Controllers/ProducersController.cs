using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_asp.Data;
using project_asp.Data.Services;
using project_asp.Models;

namespace project_asp.Controllers
{
    public class ProducersController : Controller
    {
        private readonly iProducersService _service;

        public ProducersController(iProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View("Index", allProducers);
        }

        //Get: producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("Not Found");
            }
            return View(producerDetails);
        }

        //Get: producers/create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: producers/edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("Not found");
            }
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id , [Bind("Id,ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer); 

          

            /* 
              var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
             */
        }

        //Get: producers/delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("Not found");
            }
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("Not Found");

            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
