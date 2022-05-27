using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public class Candy
    {
        public int CandyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsOnSale { get; set; }
        public int SalePercentage { get; set; }
        
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; } 
        public bool IsInStock { get; set; }
        public int AmountInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
