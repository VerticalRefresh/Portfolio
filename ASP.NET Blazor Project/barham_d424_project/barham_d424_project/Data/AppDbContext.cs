using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using barham_d424_ordermanagement.Models;

namespace barham_d424_ordermanagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID);
            modelBuilder.Entity<Customer>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserAddedID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserModifiedID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserAddedID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserModifiedID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRole>()
                .HasKey(r => r.RoleID);
            modelBuilder.Entity<Order>()
                .OwnsOne(o => o.ShippingAddress);
            modelBuilder.Entity<Customer>()
                .OwnsOne(c => c.Address);

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { RoleID = 1, RoleName = "Owner" },
                new UserRole { RoleID = 2, RoleName = "Production" },
                new UserRole { RoleID = 3, RoleName = "Admin" },
                new UserRole { RoleID = 4, RoleName = "User" });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    UserName = "production",
                    PasswordHash = "AQAAAAEAACcQAAAAEIs8B1N/inGcMjObIImMhi97N+ee6bnf11mieW68dU6fT5qJzn/XeSK65SMtLk7xpQ==",
                    RoleID = 2,
                    Name = "Production",
                    Email = "production@email.com",
                    Phone = "123-456-7890",
                    NewPassword = false,
                    UserAddedID = 1,
                    DateAdded = new DateTime(2025, 05, 12),
                    UserModifiedID = 1,
                    DateModified = new DateTime(2025, 05, 12)
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Name = "John Doe",
                    Email = "jdoe@email.com",
                    Phone = "123-456-7890",
                    UserAddedID = 1,
                    DateAdded = new DateTime(2025, 05, 12),
                    UserModifiedID = 1,
                    DateModified = new DateTime(2025, 05, 12),
                });

            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address).HasData(
                new
                {
                    CustomerId = 1,
                    Address1 = "123 Test St.",
                    Address2 = "Apt 4B",
                    City = "Test City",
                    StateCode = "CA",
                    ZipCode = "12345",
                    Country = "USA",
                });
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryID = 1, Name = "Test Category" });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Test Product",
                    CategoryId = 1,
                    Price = 19.99m,
                    NumberPerOrder = 1,
                    NumberInStock = 100,
                    Description = "This is a test product.",
                    UserAddedID = 1,
                    DateAdded = new DateTime(2025, 05, 12),
                    UserModifiedID = 1,
                    DateModified = new DateTime(2025, 05, 12)
                });
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    OrderItemID = 1,
                    OrderID = 1,
                    ProductID = 1,
                    Quantity = 2,
                    PriceAtOrder = 19.99m
                });
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1,
                    CustomerID = 1,
                    UserID = 1,
                    OrderTotal = 19.99m,
                    AmountPaid = 19.99m,
                    OrderStatus = "Completed",
                    OrderDate = new DateTime(2025, 05, 12),
                });
            modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress).HasData(
                new
                {
                    OrderID = 1,
                    Address1 = "123 Test St.",
                    Address2 = "Apt 4B",
                    City = "Test City",
                    StateCode = "CA",
                    ZipCode = "12345",
                    Country = "USA",
                });
        }

        public async Task<int> GetOrdersThisWeekAsync()
        {
            // Assuming you have an Orders DbSet and Order class
            // return await Orders.CountAsync(o => o.OrderDate >= DateTime.UtcNow.AddDays(-7));
            return 0; // Placeholder, replace with actual logic
        }

    }
}
