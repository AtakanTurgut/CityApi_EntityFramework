using CityApi.Data;
using CityApi.Data.Abstract;
using CityApi.Data.Concrete;
using CityApi.Infrastructures.Extensions;
using CityApi.Services.CityService;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Database Context
builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);   // AutoMapper

builder.Services.AddScoped<ICityService, CityManager>();    // ICityService <-- CityManager
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
