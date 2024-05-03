using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_Catlog_Application.DTOs.User;
using Movie_Catlog_Application.Interfaces.Abstract;
using Movie_Catlog_Application.Models;

namespace Movie_Catlog_Application.Controllers
{
    public class UserAuthenticationController : Controller
    {

        private readonly UserManager<ApplicationUser> userManger;
        private readonly IUserAuthenticationService service;
        public UserAuthenticationController(IUserAuthenticationService service, UserManager<ApplicationUser> userManger)
        {
            this.service = service;
            this.userManger = userManger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginUser()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await service.LoginAsync(model);

            if (result.StatusCode == 1)
            {
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await service.LogoutAsync();
            return RedirectToAction(nameof(Login));
            
        }

        [HttpPost]

        public async Task<IActionResult> Register(Register model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "User";
            var result = await service.RegisterAsync(model);
            if (result.StatusCode == 1)
            {
                
                TempData["msg"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(model);
            }
        }

        /*public async Task<IActionResult> Reg()
        {
            var model = new Register
            {
                Username = "admin11",
                Name = "Admin Subash",
                Email = "admin18@gmail.com",
                Password = "admin123"
            };
            model.Role = "admin";
            var result = await service.RegisterAsync(model);
            return Ok(result);
        }*/




    }
}
