using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Catlog_Application.Interfaces.Abstract;
using Movie_Catlog_Application.Interfaces.Implements;
using Movie_Catlog_Application.Models;
using System;
using System.Threading.Tasks;

namespace Movie_Catlog_Application.Controllers
{
    [Authorize(Roles = "admin")]
    public class GenreController : Controller
    {
        private readonly IGenericService _genericService;

        public GenreController(IGenericService genericService)
        {
            _genericService = genericService;
        }

        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<ActionResult> CreateGenre(Genre model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View("CreateGenre", "Admin");
            }


            try
            {
                await _genericService.CreateAsync(model);
                TempData["msg"] = "Genre added successfully";
                return RedirectToAction("AllGenres", "Admin");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Failed to add genre: {ex.Message}";
                return View("CreateGenre", "Admin");
            }
        }

       


    }
}
