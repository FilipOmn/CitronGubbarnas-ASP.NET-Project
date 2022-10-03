using System.ComponentModel.DataAnnotations;

namespace Candyshop.Models
{
    public class CandyRating
    {
        [Key]
        public int Id { get; set; } 
        public string CustomerName { get; set; }
        public float Rating { get; set; } 
        public Candy candy { get; set; }
        public int CandyId { get; set; }    

    }
}
