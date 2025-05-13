using System.ComponentModel.DataAnnotations;

namespace PROG7311_ST10339829_P2.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(50), EmailAddress]
        public string Contact { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Location { get; set; } = string.Empty;
    }
}