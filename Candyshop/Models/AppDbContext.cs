using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base (options)
        {

        }
        
        public DbSet<Candy> Candies { get; set; }
        public DbSet<Category> Categores { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Chocolate Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Fruit Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Gummy Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Halloween Candy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Hard Candy" });

            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 1,
                Name = "Assorted Chocolet Candy",
                Price = 4.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 1,
                ImageUrl = "\\Images\\chocolet.candy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\chocolateCandy3-small.jpg",
                IsInStock = true,
                IsOnSale=false

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 2,
                Name = "Assorted Chocolet Candy",
                Price = 3.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 1,
                ImageUrl = "\\Images\\chocolateCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\chocolateCandy-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 3,
                Name = "Assorted Chocolet Candy",
                Price = 2.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 1,
                ImageUrl = "\\Images\\chocolateCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\chocolateCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
           
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId =4,
                Name = "Assorted Fruit Candy",
                Price = 6.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 2,
                ImageUrl = "\\Images\\FruitCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\FruitCandy-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 5,
                Name = "Assorted Fruit Candy",
                Price = 3.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 2,
                ImageUrl = "\\Images\\fruitCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\fruitCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = false

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 6,
                Name = "Assorted Fruit Candy",
                Price = 4.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 2,
                ImageUrl = "\\Images\\fruitCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\fruitCandy3-small.jpg",
                IsInStock = false,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 7,
                Name = "Assorted Gummy Candy",
                Price = 4.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 3,
                ImageUrl = "\\Images\\gummyCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\gummyCandy-small.jpg",
                IsInStock = true,
                IsOnSale = false

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 8,
                Name = "Assorted Gummy Candy",
                Price = 6.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 3,
                ImageUrl = "\\Images\\gummyCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\gummyCandy2-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 9,
                Name = "Assorted Gummy Candy",
                Price = 4.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 3,
                ImageUrl = "\\Images\\gummyCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\gummyCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 10,
                Name = "Assorted Halloween Candy",
                Price = 3.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 4,
                ImageUrl = "\\Images\\halloweenCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\halloweenCandy-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 11,
                Name = "Assorted Halloween Candy",
                Price = 5.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 4,
                ImageUrl = "\\Images\\halloweenCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\halloweenCandy2-small.jpg",
                IsInStock = false,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 12,
                Name = "Assorted Halloween Candy",
                Price = 6.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 4,
                ImageUrl = "\\Images\\halloweenCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\halloweenCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 13,
                Name = "Assorted Hard Candy",
                Price = 3.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 5,
                ImageUrl = "\\Images\\hardCandy.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\hardCandy-small.jpg",
                IsInStock = true,
                IsOnSale = false

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 14,
                Name = "Assorted Hard Candy",
                Price = 2.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 5,
                ImageUrl = "\\Images\\hardCandy2.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\hardCandy2-small.jpg",
                IsInStock = false,
                IsOnSale = true

            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 15,
                Name = "Assorted Hard Candy",
                Price = 5.95M,
                Description = " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...",
                CategoryId = 5,
                ImageUrl = "\\Images\\hardCandy3.jpg",
                ImageThumbnailUrl = "\\Images\\thumbnails\\hardCandy3-small.jpg",
                IsInStock = true,
                IsOnSale = false

            });



        }

    }
}
