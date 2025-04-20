using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkingPlatform.Infrastructure;
using ParkingPlatform.Infrastructure.Models;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure PostgreSQL DbContext
builder.Services.AddDbContext<ParkingPlatformDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ParkingPlatformConnection")));

//  Add ASP.NET Core Identity with custom ApplicationUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ParkingPlatformDbContext>()
    .AddDefaultTokenProviders();

// Add controller support for API routing
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add authentication & authorization middlewares
app.UseAuthentication();
app.UseAuthorization();

// Map controller routes
app.MapControllers();

app.Run();