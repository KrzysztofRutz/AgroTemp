using AgroTemp.Infrastructure;
using AgroTemp.Application;
using AgroTemp.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPresentation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

app.UsePresentation();
app.UseApllication();

// Configure the HTTP request pipeline.


app.Run();

public partial class Program { }