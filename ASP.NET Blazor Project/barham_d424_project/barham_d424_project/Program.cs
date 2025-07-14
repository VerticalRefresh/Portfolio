using barham_d424_project;
using barham_d424_project.Data;
using barham_d424_project.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

// application builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// adds razor pages
builder.Services.AddRazorPages();

// adds server side blazor
builder.Services.AddServerSideBlazor();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// adds the db context with connection string, using retry to overcome db time-based shutdown
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()));

// adds identity with default user and role store
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.AccessDeniedPath = "/accessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization();

//Suggested, implement when relevant
//builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingServerAuthenticationStateProvider<IdentityUser>>();

//order service for getting and manipulating orders
builder.Services.AddScoped<IOrderService, OrderService>();

//build application
var app = builder.Build();


//application configuration and middleware

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//redirect from http to https
app.UseHttpsRedirection();

//serve static files
app.UseStaticFiles();

//use routing
app.UseRouting();

//use authentication and authorization
app.UseAuthentication();

app.UseAuthorization();

app.UseAntiforgery();

//for interactive server rendering - this still didn't work for me quite right, will
//implement with further investigation in App.razor, _Host.cshtml, _Imports.razor, and Index.razor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

//map blazor components
app.MapBlazorHub();

//fall back to /_host for any other requests
app.MapFallbackToPage("/_Host");

//fire application
app.Run();
