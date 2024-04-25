using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LR10_Chupyna_ASP_402
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            if (model.ConsultationDate < DateTime.Today.AddDays(1) || model.ConsultationDate.DayOfWeek == DayOfWeek.Saturday || model.ConsultationDate.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("ConsultationDate", "date should be a future weekday.");
                return View("Index", model);
            }

            if (model.Product == "Basics" && model.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("ConsultationDate", "'Basics' cannot be scheduled on Monday.");
                return View("Index", model);
            }

            return RedirectToAction("Index");
        }
    }

    public class RegistrationModel
    {
        [Required(ErrorMessage = "name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage = "invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "date is required")]
        [Display(Name = "date")]
        [DataType(DataType.Date)]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "select a product")]
        public string Product { get; set; }
    }
}
