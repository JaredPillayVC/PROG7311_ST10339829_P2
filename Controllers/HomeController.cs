using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PROG7311_ST10339829_P2.Controllers
{
    /// <summary>
    /// Controller for handling home page and user role-based redirects.
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Redirects users to their respective dashboards based on their role.
        /// </summary>
        /// <returns>Redirects to Farmer or Employee dashboard, or returns the default view.</returns>
        public IActionResult Index()
        {
            // Redirect based on user role
            if (User.IsInRole("Farmer"))
                return RedirectToAction("MyProducts", "Farmer");

            if (User.IsInRole("Employee"))
                return RedirectToAction("ViewProducts", "Employee");
            
            return View();
        }
    }
}
