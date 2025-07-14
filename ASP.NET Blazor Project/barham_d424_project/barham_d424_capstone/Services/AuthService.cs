using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using barham_d424_capstone.Data;
using barham_d424_capstone.Models;

namespace barham_d424_capstone.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CustomAuthenticationStateProvider _authenticationStateProvider;

        public AuthService(
            AppDbContext context, 
            IHttpContextAccessor httpContextAccessor, 
            AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _authenticationStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
        }

        public async Task<LoginResult> Login(string username, string password)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                return new LoginResult { Success = false };
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                 return new LoginResult { Success = false };
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!isValidPassword)
            {
                user.FailedLoginAttempts++;
                if (user.FailedLoginAttempts >= 3)
                {
                    user.LockoutEnd = DateTime.UtcNow.AddMinutes(15); // Lockout for 15 minutes
                }
                await _context.SaveChangesAsync();
                return new LoginResult { Success = false };
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString())
            };

            if (!string.IsNullOrEmpty(user.Role.RoleName))
            {
                claims.Add(new Claim(ClaimTypes.Role, user.Role.RoleName));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                new AuthenticationProperties
                {
                    IsPersistent = true, // Set to true if you want the cookie to persist across browser sessions
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Set the expiration time for the cookie
                });

            _authenticationStateProvider.NotifyUserAuthenticationStateChanged();
            return new LoginResult { Success = true, RequiresPasswordReset = user.NewPassword, UserID = user.UserID };
        }

        public async Task Logout()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                return;
            }
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _authenticationStateProvider.NotifyUserAuthenticationStateChanged();
        }

        public class LoginResult
        {
            public bool Success { get; set; }
            public bool RequiresPasswordReset { get; set; }

            public int UserID { get; set; }
        }
    }
}
