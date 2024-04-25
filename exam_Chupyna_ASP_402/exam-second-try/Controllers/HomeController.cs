using Microsoft.AspNetCore.Mvc;

namespace exam_Chupyna_ASP_402.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
