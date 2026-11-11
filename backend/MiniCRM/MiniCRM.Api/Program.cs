using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MiniCRM.Api.Data;
using MiniCRM.Api.Models;
using MiniCRM.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ASP.NET Core Identity
builder.Services
    .AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<AppDbContext>();

// Authentication cookie configuration
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

// Authorization
builder.Services.AddAuthorization();

// Application services
builder.Services.AddScoped<ICustomerService, CustomerService>();

// OpenAPI
builder.Services.AddOpenApi();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",
                "https://jolly-river-065bfee10.6.azurestaticapps.net"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// CORS must run before authentication/authorization
app.UseCors("Frontend");

// OpenAPI only locally
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Identity endpoints:
// POST /register
// POST /login
// POST /refresh
// etc.
app.MapIdentityApi<ApplicationUser>();

app.Run();