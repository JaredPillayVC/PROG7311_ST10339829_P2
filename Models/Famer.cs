using System.ComponentModel.DataAnnotations;

namespace PROG7311_ST10339829_P2.Models
{
    /// <summary>
    /// Represents a farmer entity in the system.
    /// </summary>
    public class Farmer
    {
        /// <summary>
        /// Gets or sets the farmer ID.
        /// </summary>
        public int FarmerId { get; set; }

        /// <summary>
        /// Gets or sets the farmer's name.
        /// </summary>
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the farmer's contact information.
        /// </summary>
        [Required, StringLength(50), EmailAddress]
        public string Contact { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the farmer's location.
        /// </summary>
        [Required, StringLength(100)]
        public string Location { get; set; } = string.Empty;
    }
}