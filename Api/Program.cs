using Api.Middleware;
using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injecting Business Layer
builder.Services.AddBusiness();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("mypolicy",
            builder => builder.WithOrigins("http://localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyMethod());
    });

builder.Services.Configure<ApiBehaviorOptions>(o =>
{
    o.InvalidModelStateResponseFactory = actionContext =>
        new BadRequestObjectResult(actionContext.ModelState);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("mypolicy");

app.UseHttpsRedirection();

app.UseMiddleware(typeof(ExceptionHandler));

app.UseAuthorization();

app.MapControllers();

app.Run();
