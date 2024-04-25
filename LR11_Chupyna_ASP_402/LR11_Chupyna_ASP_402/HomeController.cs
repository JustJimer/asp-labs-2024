using Microsoft.AspNetCore.Mvc;

namespace LR11_Chupyna_ASP_402
{
    public class HomeController : Controller
    {
        // Action method that will be logged by LogActionFilter
        [ServiceFilter(typeof(LogActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        // Action method that will be counted for unique users by UniqueUsersFilter
        [ServiceFilter(typeof(UniqueUsersFilter))]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
