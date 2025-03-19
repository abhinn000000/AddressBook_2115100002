using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using FluentValidation.AspNetCore;
using BusinessLayer.Services;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using BusinessLayer.Service;
using Middleware.Authenticator;
using Middleware.Email;

var builder = WebApplication.CreateBuilder(args);

//database connectivity
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<AddressBookContext>(options => options.UseSqlServer(connectionString));

//fluent validator
builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<AddressBookValidatorBL>();
});

// Configure Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["Redis:ConnectionString"];
    options.InstanceName = builder.Configuration["Redis:InstanceName"];
});


//auto mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfileBL));
builder.Services.AddScoped<IAddressBookBL, AddressBookBL>();
builder.Services.AddScoped<IAddressBookRL, AddressBookRL>();
builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddSwaggerGen();


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

//Add swagger to container

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
