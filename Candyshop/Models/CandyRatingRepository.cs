using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Candyshop.Models
{
    public class CandyRatingRepository : ICandyRatingRepository
    {
        private readonly AppDbContext _appDbContext;

        public CandyRatingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddRatingToCandy(int candyId, CandyRating candyRating)
        {
            var candy = _appDbContext.Candies.FirstOrDefault(c => c.CandyId == candyId);
            if (candy != null)
            {
                var candyrating = new CandyRating
                {
                    Rating = candyRating.Rating,
                    CustomerName = candyRating.CustomerName,
                    candy = candy,
                    CandyId = candyId
                };
                _appDbContext.CandyRatings.Add(candyrating);
                _appDbContext.SaveChanges();
            }
        }
        public IEnumerable<CandyRating> GetAllRatings()
        {
            return _appDbContext.CandyRatings;
        }
        public List<CandyRating> GetAllRatingsForSpecificCandy(int candyid)
        {
            List<CandyRating> candyRatings = new List<CandyRating>();
            var candyratingsIEnu = _appDbContext.CandyRatings.Where(c => c.CandyId == candyid);
            foreach (CandyRating rating in candyratingsIEnu)
            {
                candyRatings.Add(rating);
            }
            return candyRatings;
        }
        public static double GetAverageRating(List<CandyRating> candyRatings)
        {
            if(candyRatings.Count != 0)
            {
                float result = 0;
                foreach (var r in candyRatings)
                {
                    result = result + r.Rating;
                }
                result = result / candyRatings.Count;
                double ratingSum = Math.Round(result, 0);
                return ratingSum;

            }
            return 0;
            
        }
    }
}
