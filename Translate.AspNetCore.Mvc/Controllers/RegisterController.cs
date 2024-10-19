using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Translate.AspNetCore.Mvc.Entities;
using Translate.AspNetCore.Mvc.Models;

namespace Translate.AspNetCore.Mvc.Controllers
{
    public class RegisterController : Controller
    {

        private readonly AppDbContext _context;

        public RegisterController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration(RegisterModel model) 
        {
            if (ModelState.IsValid)
            {
                UserModel modelUser = new UserModel();
                modelUser.FirstName = model.FirstName;
                modelUser.LastName = model.LastName;
                modelUser.Email = model.Email;
                modelUser.Password = model.Password;

                try
                {
                    _context.Users.Add(modelUser);
                    _context.SaveChanges();
                    ModelState.Clear();
                    // ViewBag eklenecek kayıt olundu diye
                    return RedirectToAction("Index", "Login");

                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Lütfen E-POSTA VE ŞİFRE BENZERSİZ OLSUN.");
					return View(model);
				}
                return View();
            }
            return View(model);
        }
    }
}
