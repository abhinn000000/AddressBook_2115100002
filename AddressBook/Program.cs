using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using FluentValidation.AspNetCore;
using BusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);

//database connectivity
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<AddressBookContext>(options => options.UseSqlServer(connectionString));

//fluent validator
builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<AddressBookValidatorBL>();
});

//auto mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfileBL));


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
