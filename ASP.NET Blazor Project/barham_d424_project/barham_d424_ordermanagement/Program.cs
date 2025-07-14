using barham_d424_ordermanagement.Components;
using barham_d424_ordermanagement.Data;
using barham_d424_ordermanagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adds the razor components and interactive server components to the service collection.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Our secret connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add database context with connection string and retry on failure options
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure()));

// Add authentication and authorization services
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.AccessDeniedPath = "/access-denied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

// Add HttpContextAccessor to the DI container
builder.Services.AddHttpContextAccessor();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Enable HTTPS redirection from HTTP
app.UseHttpsRedirection();

// Enable static files to be served from wwwroot folder
app.UseStaticFiles();

// Enable Auth middleware to handle authentication and authorization
app.UseAuthentication();

app.UseAuthorization();

//Enable Antiforgery middleware to protect against CSRF attacks
app.UseAntiforgery();

//Database migrationon startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Map Razor pages to the application
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

//Run the application
app.Run();
