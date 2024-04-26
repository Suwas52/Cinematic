using Microsoft.AspNetCore.Mvc;

namespace Movie_Catlog_Application.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
