using Microsoft.EntityFrameworkCore;
using stackovergol.Data;
using stackovergol.Data.Entity;
using stackovergol.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<Match>();

var connection = builder.Configuration.GetValue<string>("MySqlConnection:MySqlConnectionString");
builder.Services.AddDbContextPool<DataContext>(
    options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 21)))
    .EnableDetailedErrors()
    .EnableDetailedErrors()
    
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();