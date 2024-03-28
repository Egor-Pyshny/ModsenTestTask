using Aplication.Interfaces;
using Aplication.Mappers;
using Aplication.UseCases.Events.Create;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Email;
using Infrastructure.Mappers;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using WebApplication3.Mappers;
using WebApplication3.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connection = builder.Configuration.GetConnectionString(
    "Host=localhost;" +
    "Port=5432;" +
    "Database=modsen;" +
    "Username=postgres;" +
"Password=postgres"
    );
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(
        connection,
        x => x.MigrationsAssembly("Infrastructure")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAutoMapper(typeof(ApplicationEventMapper));
builder.Services.AddAutoMapper(typeof(ApplicationUserMapper));
builder.Services.AddAutoMapper(typeof(InfrastructureEventMapper));
builder.Services.AddAutoMapper(typeof(InfrastructureUserMapper));
builder.Services.AddAutoMapper(typeof(WebEventMapper));
builder.Services.AddAutoMapper(typeof(WebUserMapper));

builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "local";
});

var mediatRAssemblies = new[]
{
  Assembly.GetAssembly(typeof(Event)),
  Assembly.GetAssembly(typeof(CreateEventCommand))
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
