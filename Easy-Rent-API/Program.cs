using Easy_Rent_API.Context;
using Easy_Rent_API.Services.Locations;
using Easy_Rent_API.Services.Vehicules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure the db
var connectionString = builder.Configuration.GetConnectionString("EasyRentDB");
builder.Services.AddDbContext<EasyRentContext>(optiions => optiions.UseSqlServer(connectionString));

//Services Dependecy injection
builder.Services.AddScoped<ICarTypologiesServices, CarTypologiesServices>();
builder.Services.AddScoped<IPowerSourcesServices, PowerSourceServices>();
builder.Services.AddScoped<IVehiculesServices, VehiculesServices>();
builder.Services.AddScoped<ILocationsServices, LocationServices>();




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
