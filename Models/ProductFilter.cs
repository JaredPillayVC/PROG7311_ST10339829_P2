using System;

namespace PROG7311_ST10339829_P2.Models
{
    public class ProductFilter
    {
        public int? FarmerId { get; set; }
        public string? Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
