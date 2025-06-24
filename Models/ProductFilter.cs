using System;

namespace PROG7311_ST10339829_P2.Models
{
    /// <summary>
    /// Represents filter criteria for querying products.
    /// </summary>
    public class ProductFilter
    {
        /// <summary>
        /// Gets or sets the farmer ID to filter by.
        /// </summary>
        public int? FarmerId { get; set; }
        /// <summary>
        /// Gets or sets the category to filter by.
        /// </summary>
        public string? Category { get; set; }
        /// <summary>
        /// Gets or sets the start date for filtering products.
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date for filtering products.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
