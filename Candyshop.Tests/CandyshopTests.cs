using Candyshop.Controllers;
using Candyshop.Models;
using Candyshop.ViewModels;
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
        private readonly AdminController _adminController;
        private readonly Mock<ISendMessageRepository> _messageMockRepo;

        public Tests()
        {
            _candyMockRepo = new Mock<ICandyRepository>();
            _categoryMockRepo = new Mock<ICategoryRepositoty>();
            _appDbContexMockRepo = new Mock<AppDbContext>();
            _CandyRatingRepoMockRepo = new Mock<ICandyRatingRepository>();
            _candyController = new CandyController(_candyMockRepo.Object, _categoryMockRepo.Object, _appDbContexMockRepo.Object, _CandyRatingRepoMockRepo.Object);
            _messageMockRepo = new Mock<ISendMessageRepository>();
            _adminController = new AdminController(_candyMockRepo.Object, _categoryMockRepo.Object, _appDbContexMockRepo.Object, _messageMockRepo.Object);


        }


        [SetUp]
        public void Setup()
        {


        }

        [TestCase("Tasty")]
        public void SearchFunction(string searchTerm)
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

        [TestCase]
        public void CheckForNews()
        {

            //arrange
            _candyMockRepo.Setup(repo => repo.GetAllCandy)
         .Returns(new List<Candy>() {
             new Candy { CandyId = 1, AmountInStock = 101, CategoryId = 1, Description = "candy1", ImageThumbnailUrl = "canyThumb_1.png", ImageUrl = "canyPic_1.png", IsInStock = true, IsOnSale = false, IsNew = true, Name = "QuiteTastyCandy1", Price = 100000},
             new Candy { CandyId = 2, AmountInStock = 102, CategoryId = 2, Description = "candy2", ImageThumbnailUrl = "candyThumb_2.png", ImageUrl = "canyPic_2.png", IsInStock = true, IsOnSale = false, IsNew = true, Name = "QuiteTastyCandy2", Price = 200000},
             new Candy { CandyId = 3, AmountInStock = 5000, CategoryId = 3, Description = "candy3", ImageThumbnailUrl = "candyThumb_3.png", ImageUrl = "canyPic_3.png", IsInStock = true, IsOnSale = false, IsNew = false, Name = "QuiteTastyCandy3", Price = 300000}
         });
            string category = "TestCategory";
            bool testBool = true;
            bool testIsOnSaleBool = false;

            //Act
            var result = _candyController.List(category, testBool, testIsOnSaleBool) as ViewResult;
            var candies = result.Model as CandyListViewModel;

            //Assert
            Assert.That(candies.Candies.Count, Is.EqualTo(2));
        }

        [TestCase]
        public void CheckForSales()
        {

            //arrange
            _candyMockRepo.Setup(repo => repo.GetAllCandy)
         .Returns(new List<Candy>() {
             new Candy { CandyId = 1, AmountInStock = 101, CategoryId = 1, Description = "candy1", ImageThumbnailUrl = "canyThumb_1.png", ImageUrl = "canyPic_1.png", IsInStock = true, IsOnSale = false, IsNew = false, Name = "QuiteTastyCandy1", Price = 100000, SaleStartDate = new DateTime(2023,10,10), SaleEndDate = new DateTime(2025,10,10)},
             new Candy { CandyId = 2, AmountInStock = 102, CategoryId = 2, Description = "candy2", ImageThumbnailUrl = "candyThumb_2.png", ImageUrl = "canyPic_2.png", IsInStock = true, IsOnSale = true, IsNew = false, Name = "QuiteTastyCandy2", Price = 200000, SaleStartDate = new DateTime(2022,10,10), SaleEndDate = new DateTime(2025,10,10)},
             new Candy { CandyId = 3, AmountInStock = 5000, CategoryId = 3, Description = "candy3", ImageThumbnailUrl = "candyThumb_3.png", ImageUrl = "canyPic_3.png", IsInStock = true, IsOnSale = true, IsNew = false, Name = "QuiteTastyCandy3", Price = 300000, SaleStartDate = new DateTime(2022,10,10), SaleEndDate = new DateTime(2025,10,10)}
         });
            string category = "HOT SALES";
            bool testIsNewBool = false;
            bool testIsOnSale = true;

            //Act
            var result = _candyController.List(category, testIsNewBool, testIsOnSale) as ViewResult;
            var candies = result.Model as CandyListViewModel;

            //Assert
            Assert.That(candies.Candies.Count, Is.EqualTo(2));
        }
        
        [TestCase]
        public void CheckForMessage()
        {    
            //arrange
            _messageMockRepo.Setup(repo => repo.GetAllMessages)
                .Returns(new List<SendMessage>(){
                new SendMessage {id = 1, Name = "test", Email = "test@gmail.com", Subject = "test", Message = "test" },
                new SendMessage {id = 2, Name = "test", Email = "test@gmail.com", Subject = "test", Message = "test" },
                new SendMessage {id = 3, Name = "test", Email = "test@gmail.com", Subject = "test", Message = "test" }
            });

            //Act
            var result = _adminController.Messages() as ViewResult;
            var messages = result.Model as SendMessageViewModel;
            
            
            //Assert
            Assert.That(messages.SendMessages.Count, Is.EqualTo(3));
        }

    }
}