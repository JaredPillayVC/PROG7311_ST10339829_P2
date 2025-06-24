using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using PROG7311_ST10339829_P2.Models;
using PROG7311_ST10339829_P2.Repository.Interfaces;

namespace PROG7311_ST10339829_P2.Controllers
{
    /// <summary>
    /// Controller for employee-specific actions and views.
    /// </summary>
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly IFarmerRepository _farmerRepo;
        private readonly IProductRepository _productRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        public EmployeeController(
            IFarmerRepository farmerRepo,
            IProductRepository productRepo)
        {
            _farmerRepo = farmerRepo;
            _productRepo = productRepo;
        }

        /// <summary>
        /// Shows the Add Farmer form.
        /// </summary>
        public IActionResult AddFarmer()
        {
            return View(new Farmer());
        }

        /// <summary>
        /// Handles the Add Farmer form submission.
        /// </summary>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFarmer(Farmer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _farmerRepo.AddFarmerAsync(model);
                TempData["Success"] = "Farmer added successfully!";
                return RedirectToAction(nameof(ViewProducts));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred adding the farmer.");
                return View(model);
            }
        }

        /// <summary>
        /// Displays and filters the list of products for employees.
        /// </summary>
        public async Task<IActionResult> ViewProducts(ProductFilter filter)
        {
            var farmers = await _farmerRepo.GetAllFarmersAsync();
            ViewBag.FarmerList = new SelectList(
                farmers, nameof(Farmer.FarmerId), nameof(Farmer.Name), filter.FarmerId);

            var categories = await _productRepo.GetAllCategoriesAsync();
            ViewBag.CategoryList = new SelectList(categories, filter.Category);


            var products = await _productRepo.GetAllProductsAsync(
                filter.FarmerId, filter.Category, filter.StartDate, filter.EndDate);

            
            var vm = new ProductListViewModel
            {
                Filter = filter,
                Products = products
            };

            return View(vm);
        }
    }
}
