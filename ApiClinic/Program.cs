using EFMedical.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ClinicContext>(options =>
options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ClinicDB;Trusted_Connection=True;"));


var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapControllers();

app.Run();
