using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Movie_Catlog_Application.Interfaces.Abstract;
using Movie_Catlog_Application.Interfaces.Implements;
using Movie_Catlog_Application.Models;

namespace Movie_Catlog_Application.Controllers
{
    [Authorize(Roles = "admin")]
    public class MoviesController : Controller
    {
        private readonly IGenericService genericService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public MoviesController(IGenericService genericService, IWebHostEnvironment webHostEnvironment)
        {
            this.genericService = genericService;
            this.webHostEnvironment = webHostEnvironment;
        }
        /*public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MovieCreate(Movie model, IFormFile imageFile)
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
                return View(nameof(model));
            }


            try
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;

                if (imageFile != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Image/MovieUpload/");
                    string filePath = Path.Combine(productPath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }

                    model.MovieImage = @"s/Image/MovieUpload/" + fileName;
                }

                await genericService.CreateAsync(model);
                TempData["msg"] = "Movies added successfully";
                return RedirectToAction("CreateMovies", "Movies");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Failed to add genre: {ex.Message}";
                return View("CreateMovies", "Movies");
            }
        }*/
    }
}
