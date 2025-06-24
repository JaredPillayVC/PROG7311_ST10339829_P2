using System;
using System.ComponentModel.DataAnnotations;

namespace PROG7311_ST10339829_P2.Models
{
    /// <summary>
    /// Represents a product entity in the system.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the farmer ID associated with the product.
        /// </summary>
        [Required]
        public int FarmerId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        [Required, StringLength(50)]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the production date of the product.
        /// </summary>
        [Required, DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
    }
}