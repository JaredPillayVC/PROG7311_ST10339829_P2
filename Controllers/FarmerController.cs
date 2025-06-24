using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROG7311_ST10339829_P2.Models;
using PROG7311_ST10339829_P2.Repository.Interfaces;
using System.Threading.Tasks;

namespace PROG7311_ST10339829_P2.Controllers
{
    /// <summary>
    /// Controller for farmer-specific actions and views.
    /// </summary>
    [Authorize(Roles = "Farmer")]
    public class FarmerController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="FarmerController"/> class.
        /// </summary>
        public FarmerController(
            IProductRepository productRepo,
            UserManager<ApplicationUser> userManager)
        {
            _productRepo = productRepo;
            _userManager = userManager;
        }

        /// <summary>
        /// Displays the list of products for the current farmer.
        /// </summary>
        public async Task<IActionResult> MyProducts()
        {
            var user = await _userManager.GetUserAsync(User);
            var farmerId = user.FarmerId ?? 0;
            var products = await _productRepo.GetProductsByFarmerAsync(farmerId);
            return View(products);
        }

        /// <summary>
        /// Shows the Add Product form.
        /// </summary>
        public IActionResult AddProduct() => View();

        /// <summary>
        /// Handles the Add Product form submission.
        /// </summary>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var user = await _userManager.GetUserAsync(User);
                model.FarmerId = user.FarmerId ?? 0;
                await _productRepo.AddProductAsync(model);
                TempData["Success"] = "Product added successfully!";
                return RedirectToAction(nameof(MyProducts));
            }
            catch (Exception ex)
            {
                // Log exception (ex) as needed
                ModelState.AddModelError("", "An error occurred saving your product.");
                return View(model);
            }
        }
    }
}
