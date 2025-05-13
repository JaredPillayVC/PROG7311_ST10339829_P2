using System;
using System.ComponentModel.DataAnnotations;

namespace PROG7311_ST10339829_P2.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public int FarmerId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
    }
}