using System.Collections.Generic;

namespace Candyshop.Models
{
    public interface ICandyRatingRepository
    {
        public void AddRatingToCandy(int candyId, CandyRating candyRating);
        public IEnumerable<CandyRating> GetAllRatings();
        public List<CandyRating> GetAllRatingsForSpecificCandy(int candyid);



    }
}
