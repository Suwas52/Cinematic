using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Movie_Catlog_Application.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        public IActionResult Display()
        {
            return View();
        }
    }
}
