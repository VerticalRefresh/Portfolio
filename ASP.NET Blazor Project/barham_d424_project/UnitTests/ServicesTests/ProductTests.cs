using barham_d424_capstone.Data;
using barham_d424_capstone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace barham_d424_capstone.Tests
{
    public class ProductTests
    {
        [Fact]
        public async Task AddProduct_IncreasesProductCount()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "ProductTestDb")
                .Options;

            using var context = new AppDbContext(options);

            var initialCount = context.Products.Count();

            var newProduct = new Product
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 9.99m,
                CategoryId = 1,
                NumberPerOrder = 1,
                NumberInStock = 10,
                DateAdded = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                UserAddedID = 1,
                UserModifiedID = 1
            };

            // Act
            context.Products.Add(newProduct);
            await context.SaveChangesAsync();

            var finalCount = context.Products.Count();

            // Assert
            Assert.Equal(initialCount + 1, finalCount);
        }
    }
}