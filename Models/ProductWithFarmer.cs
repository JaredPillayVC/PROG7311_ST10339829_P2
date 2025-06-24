using System;

namespace PROG7311_ST10339829_P2.Models
{
    /// <summary>
    /// ViewModel representing a product along with its associated farmer's details.
    /// </summary>
    public class ProductWithFarmer
    {
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        public string Category { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the production date.
        /// </summary>
        public DateTime ProductionDate { get; set; }
        /// <summary>
        /// Gets or sets the farmer ID.
        /// </summary>
        public int FarmerId { get; set; }
        /// <summary>
        /// Gets or sets the farmer's name.
        /// </summary>
        public string FarmerName { get; set; } = string.Empty;
    }
}
