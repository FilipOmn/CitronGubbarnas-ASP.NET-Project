using Candyshop.Models;
using System.Collections;
using System.Collections.Generic;

namespace Candyshop.ViewModels
{
    public class CandyViewModel
    {
        public Candy Candy { get; set; }
        public CandyRating CandyRating { get; set; }
        public double RatingSum { get; set; }   
        public List<CandyRating> CandyRatings { get; set; }   
    }
}
