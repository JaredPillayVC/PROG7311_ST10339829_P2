using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PROG7311_ST10339829_P2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Farmer"))
                return RedirectToAction("MyProducts", "Farmer");

            if (User.IsInRole("Employee"))
                return RedirectToAction("ViewProducts", "Employee");
            
            return View();
        }
    }
}
