using System.Collections.Generic;

namespace PROG7311_ST10339829_P2.Models
{
    /// <summary>
    /// ViewModel for displaying a filtered list of products.
    /// </summary>
    public class ProductListViewModel
    {
        /// <summary>
        /// Gets or sets the filter applied to the product list.
        /// </summary>
        public ProductFilter Filter { get; set; } = new ProductFilter();
        /// <summary>
        /// Gets or sets the collection of products with farmer details.
        /// </summary>
        public IEnumerable<ProductWithFarmer> Products { get; set; }
            = new List<ProductWithFarmer>();
    }
}
