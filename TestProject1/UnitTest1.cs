using Candyshop.Controllers;
using Candyshop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Candyshop.Tests
{
    public class Tests
    {
        private readonly Mock<ICandyRepository> _candyMockRepo;
        private readonly Mock<ICategoryRepositoty> _categoryMockRepo;
        private readonly Mock<AppDbContext> _appDbContexMockRepo;
        private readonly Mock<ICandyRatingRepository> _CandyRatingRepoMockRepo;
        private readonly CandyController _candyController;
        

        public Tests()
        {
            _candyMockRepo = new Mock<ICandyRepository>();
            _categoryMockRepo = new Mock<ICategoryRepositoty>();
            _appDbContexMockRepo = new Mock<AppDbContext>();
            _CandyRatingRepoMockRepo = new Mock<ICandyRatingRepository>();
            _candyController = new CandyController(_candyMockRepo.Object, _categoryMockRepo.Object, _appDbContexMockRepo.Object, _CandyRatingRepoMockRepo.Object);

            
        }


        [SetUp]
        public void Setup()
        {
            

        }

        [TestCase("Tasty")]
        public void SearchFunction( string searchTerm)
        {

            //arrange
            _candyMockRepo.Setup(repo => repo.GetAllCandy)
         .Returns(new List<Candy>() {
             new Candy { CandyId = 1, AmountInStock = 101, CategoryId = 1, Description = "candy1", ImageThumbnailUrl = "canyThumb_1.png", ImageUrl = "canyPic_1.png", IsInStock = true, IsOnSale = false, Name = "QuiteTastyCandy1", Price = 100000},
             new Candy { CandyId = 2, AmountInStock = 102, CategoryId = 2, Description = "candy2", ImageThumbnailUrl = "candyThumb_2.png", ImageUrl = "canyPic_2.png", IsInStock = true, IsOnSale = false, Name = "QuiteTastyCandy2", Price = 200000}
         });

            //Act
            var result = _candyController.CandySearch(searchTerm) as ViewResult;
            var candies = result.Model as List<Candy>;

            //Assert
            Assert.That(candies.Count, Is.EqualTo(2));
        }

        [TestCase]
        public void CalculateAverageRating()
        {
            //Assign
            List<CandyRating> testRatings = new List<CandyRating>();
            testRatings.Add(new CandyRating { Rating = 2 });
            testRatings.Add(new CandyRating { Rating = 5 });
            testRatings.Add(new CandyRating { Rating = 1 });

            //Act
            var result = CandyRatingRepository.GetAverageRating(testRatings);
            int resulttoint = Convert.ToInt32(result);

            //Assert
            Assert.That(resulttoint, Is.EqualTo(3));
        }
    }
}