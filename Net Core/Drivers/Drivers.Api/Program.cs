using Drivers.Core.Entities;
using Drivers.Core.IRepository;
using Drivers.Core.Iservice;
using Drivers.Data;
using Drivers.Data.Repository;
using Drivers.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IService<DriverEntity>, DriversService>();
builder.Services.AddScoped<IService<TravelEntity>, TravelsService>();
builder.Services.AddScoped<IService<PassengerEntity>, PassengersService>();
builder.Services.AddScoped<IService<FeedbackEntity>, FeedbacksService>();


builder.Services.AddScoped<IRepository<DriverEntity>, DriversRepository>();
builder.Services.AddScoped<IRepository<TravelEntity>, TravelsRepository>();
builder.Services.AddScoped<IRepository<PassengerEntity>, PassengersRepository>();
builder.Services.AddScoped<IRepository<FeedbackEntity>, FeedbacksRepository>();

builder.Services.AddSingleton<DataContext>();

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
