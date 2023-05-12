using Microsoft.AspNetCore.Mvc;
using project_asp.Data.Services;
using project_asp.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace project_asp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
         public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {  /*
            if (!ModelState.IsValid)
            {
                var fullNameErrors = ModelState["FullName"].Errors;
                var profilePictureUrlErrors = ModelState["ProfilePictureURL"].Errors;
                foreach (var error in fullNameErrors)
                {
                    Console.WriteLine("ename: " + error.ErrorMessage);
                }

                foreach (var error in profilePictureUrlErrors) ;
                {
                    Console.WriteLine("eprofile Error: " + error.ErrorMessage);
                }
                return View(actor);
            } */
           await  _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id , [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {  /*
            if (!ModelState.IsValid)
            {
                var fullNameErrors = ModelState["FullName"].Errors;
                var profilePictureUrlErrors = ModelState["ProfilePictureURL"].Errors;
                foreach (var error in fullNameErrors)
                {
                    Console.WriteLine("ename: " + error.ErrorMessage);
                }

                foreach (var error in profilePictureUrlErrors) ;
                {
                    Console.WriteLine("eprofile Error: " + error.ErrorMessage);
                }
                return View(actor);
            } */
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            /*
            if (!ModelState.IsValid)
            {
                var fullNameErrors = ModelState["FullName"].Errors;
                var profilePictureUrlErrors = ModelState["ProfilePictureURL"].Errors;
                foreach (var error in fullNameErrors)
                {
                    Console.WriteLine("ename: " + error.ErrorMessage);
                }

                foreach (var error in profilePictureUrlErrors) ;
                {
                    Console.WriteLine("eprofile Error: " + error.ErrorMessage);
                }
                return View(actor);
            } */
           
            return RedirectToAction(nameof(Index));
        }

    }
}
