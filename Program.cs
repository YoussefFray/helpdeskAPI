using HelpDesk.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dependency injection of dbcontext class
builder.Services.AddDbContext<HelpDeskContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HelpDesk"))
        );

builder.Services.AddCors(p=>p.AddPolicy("corspolicy",build=>
{
    build.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
