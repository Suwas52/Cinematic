using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Movie_Catlog_Application.Interfaces.Abstract;
using Movie_Catlog_Application.Interfaces.Implements;
using Movie_Catlog_Application.Models;

namespace Movie_Catlog_Application.Controllers
{
    [Authorize(Roles ="admin")]
    
    public class AdminController : Controller
    {
        private readonly IGenericService genericService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdminController(IGenericService genericService, IWebHostEnvironment webHostEnvironment)
        {
            this.genericService = genericService;
            this.webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult CreateGenre()
        {
            return View();
        }

        public async  Task<IActionResult> AllGenres()
        {
            var result = await genericService.GetAllAsync<Genre>();
            return View(result);
        }

        public async Task<IActionResult> EditGenre(int id)
        {
            var genre = await genericService.GetByIdAsync<Genre>(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> EditGenre(int id, Genre model)
        {
            if (id != model.GenreId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await genericService.UpdateAsync(model);
                TempData["msg"] = "Genre updated successfully";
                return RedirectToAction("AllGenres", "Admin");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Failed to update genre: {ex.Message}";
                return View(model);
            }
        }

        
        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var genre = await genericService.GetByIdAsync<Genre>(id);
                if (genre == null)
                {
                    return NotFound();
                }
                await genericService.DeleteAsync(genre);
                TempData["msg"] = "Genre deleted successfully";
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Failed to delete genre: {ex.Message}";
            }
            return RedirectToAction("AllGenres", "Admin");
        }




        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovie(Movie model, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/movies");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    await using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    model.MovieImage = "/images/movies/" + uniqueFileName;
                }

                await genericService.CreateAsync(model);
                TempData["msg"] = "Movie added successfully";
                return RedirectToAction(nameof(CreateMovie));
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Failed to add movie: {ex.Message}";
                return View(model);
            }
        }

        /*[HttpPost]
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
                return RedirectToAction("CreateMovie", "Admin");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Failed to add genre: {ex.Message}";
                return View("CreateMovies", "Movies");
            }
        }*/



    }
}
