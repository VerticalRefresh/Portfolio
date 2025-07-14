using barham_d424_capstone.Data;
using barham_d424_capstone.Models;
using barham_d424_capstone.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace barham_d424_capstone.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task Login_WithValidCredentials_ReturnsSuccessTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "LoginTestDb")
                .Options;

            using var context = new AppDbContext(options);
            var testUser = new User
            {
                UserName = "testuser",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("testpassword"),
                Role = new UserRole { RoleName = "Admin" },
                Email = "test@example.com",
                Phone = "1234567890",
                Name = "Test User"
            };
            context.Users.Add(testUser);
            context.SaveChanges();

            var httpContextAccessor = new HttpContextAccessor
            {
                HttpContext = new DefaultHttpContext()
            };

            // Mock the authentication service
            httpContextAccessor.HttpContext.RequestServices = new ServiceCollection()
                .AddSingleton<IAuthenticationService, MockAuthenticationService>()
                .BuildServiceProvider();

            // Set dummy user to prevent null ref
            httpContextAccessor.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            var authStateProvider = new CustomAuthenticationStateProvider(httpContextAccessor);
            var authService = new AuthService(context, httpContextAccessor, authStateProvider);

            // Act
            var result = await authService.Login("testuser", "testpassword");

            // Assert
            Assert.True(result.Success);
            Assert.False(result.RequiresPasswordReset); // sanity check
            Assert.True(result.UserID > 0); // sanity check
        }
    }

    // Mock authentication service so SignInAsync doesn't fail
    public class MockAuthenticationService : IAuthenticationService
    {
        public Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string scheme)
            => Task.FromResult(AuthenticateResult.NoResult());

        public Task ChallengeAsync(HttpContext context, string scheme, AuthenticationProperties properties)
            => Task.CompletedTask;

        public Task ForbidAsync(HttpContext context, string scheme, AuthenticationProperties properties)
            => Task.CompletedTask;

        public Task SignInAsync(HttpContext context, string scheme, ClaimsPrincipal principal, AuthenticationProperties properties)
            => Task.CompletedTask;

        public Task SignOutAsync(HttpContext context, string scheme, AuthenticationProperties properties)
            => Task.CompletedTask;
    }
}
