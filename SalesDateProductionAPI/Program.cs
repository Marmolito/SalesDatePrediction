using Domain.Aplication;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Domain.Iapi;
using SalesDatePrediction.Domain.Ispi;
using SalesDateProduction.Aplication;
using SalesDateProduction.Aplication.Mappers;
using SalesDateProductionAPI.Out;
using System;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<HotelesContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IHandlerEmployee, ImpHandlerEmployee>();
builder.Services.AddScoped<IEmployee, UseCaseEmployee>();
builder.Services.AddScoped<IEmployeePersistancePort, EmployeeEntity>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
