using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Translate.AspNetCore.Mvc.Entities;
using Translate.AspNetCore.Mvc.Models;
using Translate.AspNetCore.Mvc.service;
using Translate.AspNetCore.Mvc.Filters;

namespace Translate.AspNetCore.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userService.ValidateUserAsync(model.Email, model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, "User")
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "E-POSTA VEYA ŞİFRE HATALI.");
                return View(model);
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
