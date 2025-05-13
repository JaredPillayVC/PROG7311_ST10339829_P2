using System.Collections.Generic;

namespace PROG7311_ST10339829_P2.Models
{
    public class ProductListViewModel
    {
        public ProductFilter Filter { get; set; } = new ProductFilter();
        public IEnumerable<ProductWithFarmer> Products { get; set; }
            = new List<ProductWithFarmer>();
    }
}
