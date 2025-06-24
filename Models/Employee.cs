using System.ComponentModel.DataAnnotations;

namespace PROG7311_ST10339829_P2.Models
{
    /// <summary>
    /// Represents an employee entity in the system.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the user ID (foreign key to AspNetUsers).
        /// </summary>
        [Required]
        public string UserId { get; set; } = string.Empty;   // FK to AspNetUsers.Id

        /// <summary>
        /// Gets or sets the employee's full name.
        /// </summary>
        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the employee's contact number.
        /// </summary>
        [Required, Phone, StringLength(50)]
        public string ContactNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the employee's department.
        /// </summary>
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;
    }
}
