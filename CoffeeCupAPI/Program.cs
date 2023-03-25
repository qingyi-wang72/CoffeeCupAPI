global using CoffeeCupAPI.Dtos;
global using CoffeeCupAPI.Models;
global using CoffeeCupAPI.Controllers;
global using CoffeeCupAPI.Services.CoffeeCupService;
global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register the service
builder.Services.AddScoped<ICoffeeCupService, CoffeeCupService>();

// register the context
builder.Services.AddDbContext<CoffeeCupContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeCupContext")));

// register the AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c => {
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoffeeCup API V1");
    //    c.RoutePrefix = string.Empty;
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

