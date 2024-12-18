using app_store.Application.Behaviors;
using app_store.Application.Commands.Users.CreateUser;
using app_store.Application.Configurations;
using app_store.Domain.Interfaces;
using app_store.Infrastructure.Services;
using app_store.Infrastructure.SqlServer;
using app_store.Infrastructure.SqlServer.DbContexts;
using app_store.Infrastructure.SqlServer.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Reflection;

//Serilog configurations
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/Log.txt",rollingInterval:RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();
    
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("https://localhost:7168") // آدرس فرانت‌اند شما
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
//Add serilog
builder.Host.UseSerilog();
// Add services to the container
builder.Services.AddControllers();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

//Add respositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject file storage settings from AppSetting
var fileStorageSettings = builder.Configuration.GetSection("FileStorage").Get<FileStorageSettings>();
builder.Services.AddSingleton(fileStorageSettings);

//Add SqlServer
string? connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddSqlServer<AppStoreDbContext>(connectionString);
//MediatR Config
builder.Services.RegisterApplication();
//Add fluent validators
builder.Services.AddFluentValidation(fv =>
{ 
    fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
