using Microsoft.EntityFrameworkCore;
using moongy.labs.internships.DataAccess;
using Moongy.Labs.Internships.Business.Services;
using Moongy.Labs.Internships.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Data Access Layer
builder.Services.AddScoped<IInternshipRepository, InternshipRepository>();

// Business Layer
builder.Services.AddScoped<IInternshipService, InternshipService>();

// CORS React Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("ReactPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
