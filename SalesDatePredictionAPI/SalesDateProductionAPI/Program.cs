using Domain.Aplication;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Domain.Iapi;
using SalesDatePrediction.Domain.Ispi;
using SalesDateProduction.Aplication;
using SalesDateProduction.Aplication.Mappers;
using SalesDateProductionAPI.Mappers;
using SalesDateProductionAPI.Out;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<HotelesContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));


builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(CustomerModelDtoProfile));
builder.Services.AddAutoMapper(typeof(CustomerEntityModelProfile));
builder.Services.AddAutoMapper(typeof(EmployeeModelDtoProfile));
builder.Services.AddAutoMapper(typeof(EmployeeEntityModelProfile));
builder.Services.AddAutoMapper(typeof(OrderEntityModelProfile));
builder.Services.AddAutoMapper(typeof(OrderModelDtoProfile));

builder.Services.AddScoped<IHandlerOrder, ImpHandlerOrder>();
builder.Services.AddScoped<IOrder, UseCaseOrder>();
builder.Services.AddScoped<IOrderPersistancePort, Order>();

builder.Services.AddScoped<IHandlerCustomer, ImpHandlerCustomer>();
builder.Services.AddScoped<ICustomer, UseCaseCustomer>();
builder.Services.AddScoped<ICustomerPersistancePort, Customer>();

builder.Services.AddScoped<IHandlerEmployee, ImpHandlerEmployee>();
builder.Services.AddScoped<IEmployee, UseCaseEmployee>();
builder.Services.AddScoped<IEmployeePersistancePort, Employee>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Registrar el middleware de manejo de excepciones
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
