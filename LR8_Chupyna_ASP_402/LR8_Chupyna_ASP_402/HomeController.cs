using Microsoft.AspNetCore.Mvc;

namespace LR8_Chupyna_ASP_402
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product { ID = 1, Name = "lastMinuteLabs", Price = 10.99m, CreatedDate = DateTime.Now.AddDays(-5) },
                new Product { ID = 2, Name = "pizza orders here", Price = 20.99m, CreatedDate = DateTime.Now.AddDays(-3) },
                new Product { ID = 3, Name = "something else here", Price = 15.99m, CreatedDate = DateTime.Now.AddDays(-1) }
            };

            return View(products);
        }
    }
}
