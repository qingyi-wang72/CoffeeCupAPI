global using CoffeeCupAPI.Models;
global using CoffeeCupAPI.Controllers;
global using CoffeeCupAPI.Models.RequestModels;
global using CoffeeCupAPI.Services.CoffeeCupService;
global using AutoMapper;
global using System.Net;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Logging;
global using Microsoft.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register the service
builder.Services.AddScoped<ICoffeeCupService, CoffeeCupService>();

// register the context
builder.Services.AddDbContext<CoffeeCupContext>(options => options.UseInMemoryDatabase("CoffeeCupsDb"));

// register the AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

