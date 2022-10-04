using Candyshop.Controllers;
using Candyshop.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Candyshop.Tests
{
    public class Tests
    {
        private readonly ICandyRepository candyRepository;
        private readonly ICategoryRepositoty categoryRepository;
        private readonly AppDbContext appDbContext;
        private readonly ICandyRatingRepository candyRatingRepository;

        private Controllers.CandyController _candyController { get; set; } = null!;
        

        [SetUp]
        public void Setup()
        {
           


        }

        [TestCase("Kim")]
        
        public void SearchFunction( string testWord)
        {

            //Assign

               
            _candyController = new CandyController(candyRepository,categoryRepository,appDbContext,candyRatingRepository);

            var searchResult = _candyController.CandySearch(testWord);

            //Assert

            Assert.False(searchResult.isEmpty());
        }
    }
}