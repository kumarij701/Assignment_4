using Assignment_4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment_4.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [System.Web.Mvc.HandleError(ExceptionType = typeof(NullReferenceException), View = "AnotherError")]
        public IActionResult Index()
        {
            string testVal = null;
            var some = testVal;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}