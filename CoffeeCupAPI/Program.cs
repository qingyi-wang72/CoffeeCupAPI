global using Microsoft.EntityFrameworkCore;
global using CoffeeCupAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register the DataContext
builder.Services.AddDbContext<CoffeeCupContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeCupContext")));

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

