using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UnitOfWork.Students.Data.EFCore.Context;
using UnitOfWork.Students.Data.EFCore.Repositories;
using UnitOfWork.Students.Domain.Interfaces;
using UnitOfWork.Students.Domain.Interfaces.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork.Students.Data.EFCore.Implementation.UnitOfWork>();

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

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
