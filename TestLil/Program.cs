using Microsoft.EntityFrameworkCore;
using TestLil.Abstraction;
using TestLil.Aplication;
using TestLil.DataAccess;
using TestLil.Entities;
using TestLil.Repository;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
builder.WebHost.UseUrls("http://*:8080");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepositoryProductos<>), typeof(RepositoryProductos<>));
builder.Services.AddScoped(typeof(IProductoAplication<>), typeof(ProductoAplication<>));                                                                     
builder.Services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));


var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

builder.Services.AddDbContext<ApiDbContext>(options =>
options.UseMySql(config.GetConnectionString("DefaultConnection"),
serverVersion,
b => b.MigrationsAssembly("TestLil"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
