using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ToDoAppDbContext>( options =>
{
	var serverName = Environment.MachineName; 
	string connectionString = builder.Configuration.GetConnectionString("ToDoApp").Replace("{ServerName}", serverName);

	options.UseSqlServer(connectionString);
}
);

builder.Services.AddAutoMapper(typeof(AutomapperProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "To-Do API",
		Description = "API for a Task Management app, built with .NET8 and minimal APIs",
	});

	options.EnableAnnotations();
});

builder.Services.AddSingleton<ITodoApplicationServices, TodoApplicationServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ApiEndpoints.MapTodoEndpoints(app);

app.Run();


