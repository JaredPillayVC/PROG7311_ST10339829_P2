using Microsoft.AspNetCore.Identity;

namespace PROG7311_ST10339829_P2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? FarmerId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
