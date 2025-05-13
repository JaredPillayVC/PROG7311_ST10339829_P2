using System.ComponentModel.DataAnnotations;

namespace PROG7311_ST10339829_P2.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string UserId { get; set; }   // FK to AspNetUsers.Id

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, Phone, StringLength(50)]
        public string ContactNumber { get; set; }

        [StringLength(100)]
        public string Department { get; set; }
    }
}
