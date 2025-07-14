using barham_d424_project.Models;
using Microsoft.AspNetCore.Identity;
using barham_d424_project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets<Program>()
            .Build();
        //production
        //DevAdmin!23
        var connectionString = config.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using var context = new AppDbContext(optionsBuilder.Options);

        Console.Write("Username: ");
        var inputUsername = Console.ReadLine();

        Console.Write("Password: ");
        var inputPassword = Console.ReadLine();

        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == inputUsername);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, inputPassword);

        if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
        {
            Console.WriteLine("Password is correct.");
        }
        else
        {
            Console.WriteLine("Password is incorrect.");
        }
    }
}
