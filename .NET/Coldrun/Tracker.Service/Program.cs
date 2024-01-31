using FluentValidation;
using System.Reflection;
using Tracker.ApplicationCore.Commands;
using Tracker.ApplicationCore.Queries;
using Tracker.Core;
using Tracker.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(GetTrucksQuery).Assembly, typeof(CreateTruckCommand).Assembly));
builder.Services.AddCors();

builder.Services.AddSingleton<ITruckRepository, InMemoryTruckRepository>();
builder.Services.AddTransient<ITruckState, TruckState>();

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