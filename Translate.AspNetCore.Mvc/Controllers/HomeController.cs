using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Translate.AspNetCore.Mvc.Entities;
using Translate.AspNetCore.Mvc.Models;

namespace Translate.AspNetCore.Mvc.Controllers
{
	public class HomeController : Controller
	{
	   private readonly ILogger<HomeController> _logger;
    private readonly ITranslationService _translationService;

    public HomeController(ILogger<HomeController> logger, ITranslationService translationService)
    {
        _logger = logger;
        _translationService = translationService;
    }
        [HttpPost]
    public IActionResult Translate(string word, string fromLang, string toLang)
    {
        var translationResult = _translationService.Translate(word, fromLang, toLang);
    ViewBag.Translation = translationResult;
    
  
    ViewBag.Word = word;
    ViewBag.FromLang = fromLang;
    ViewBag.ToLang = toLang;

    return View("Index");
    }


        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}