using Microsoft.AspNetCore.Mvc;

namespace exam_Chupyna_ASP_402
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Tag Helper Demo";
            return View();
        }
    }
}
