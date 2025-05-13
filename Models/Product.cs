using System;

namespace PROG7311_ST10339829_P2.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int FarmerId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
