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
builder.Services.AddAutoMapper(typeof(OrderProductDtoModelProfile));
builder.Services.AddAutoMapper(typeof(ProductModelDtoProfile));
builder.Services.AddAutoMapper(typeof(ProductEntityModelProfile));
builder.Services.AddAutoMapper(typeof(ShipperModelDtoProfile));
builder.Services.AddAutoMapper(typeof(ShipperEntityModelProfile));
builder.Services.AddAutoMapper(typeof(CustomerModelDtoProfile));
builder.Services.AddAutoMapper(typeof(CustomerEntityModelProfile));
builder.Services.AddAutoMapper(typeof(EmployeeModelDtoProfile));
builder.Services.AddAutoMapper(typeof(EmployeeEntityModelProfile));
builder.Services.AddAutoMapper(typeof(OrderEntityModelProfile));
builder.Services.AddAutoMapper(typeof(OrderModelDtoProfile));

builder.Services.AddScoped<IHandlerProduct, ImpHandlerProduct>();
builder.Services.AddScoped<IProduct, UseCaseProduct>();
builder.Services.AddScoped<IProductOutAdo, Product>();

builder.Services.AddScoped<IHandlerShipper, ImpHandlerShipper>();
builder.Services.AddScoped<IShipper, UseCaseShipper>();
builder.Services.AddScoped<IShipperOutAdo, Shipper>();

builder.Services.AddScoped<IHandlerOrder, ImpHandlerOrder>();
builder.Services.AddScoped<IOrder, UseCaseOrder>();
builder.Services.AddScoped<IOrderOutAdo, Order>();

builder.Services.AddScoped<IHandlerCustomer, ImpHandlerCustomer>();
builder.Services.AddScoped<ICustomer, UseCaseCustomer>();
builder.Services.AddScoped<ICustomerOutAdo, Customer>();

builder.Services.AddScoped<IHandlerEmployee, ImpHandlerEmployee>();
builder.Services.AddScoped<IEmployee, UseCaseEmployee>();
builder.Services.AddScoped<IEmployeeOutAdo, Employee>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();
// Registrar el middleware de manejo de excepciones
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("NuevaPolitica");
app.UseAuthorization();

app.MapControllers();

app.Run();
