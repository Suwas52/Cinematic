using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Catlog_Application.Interfaces.Abstract;
using Movie_Catlog_Application.Models;

namespace Movie_Catlog_Application.Controllers
{
    [Authorize(Roles = "admin")]
    public class GenreController : Controller
    {
        private readonly IGenericService service;

        public GenreController(IGenericService service)
        {
            this.service = service;
        }
        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateGenrePost(Genre model)
        {
            if(ModelState.IsValid)
            {
                await service.CreateAsync(model);

                return RedirectToAction("Home");
            }

            return View(model);
        }
    }
}
