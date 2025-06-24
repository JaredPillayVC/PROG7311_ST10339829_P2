using Microsoft.AspNetCore.Identity;

namespace PROG7311_ST10339829_P2.Models
{
    /// <summary>
    /// Represents an application user with optional links to Farmer or Employee entities.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the FarmerId if the user is a farmer.
        /// </summary>
        public int? FarmerId { get; set; }
        /// <summary>
        /// Gets or sets the EmployeeId if the user is an employee.
        /// </summary>
        public int? EmployeeId { get; set; }
    }
}
