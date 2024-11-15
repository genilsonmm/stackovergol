using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using stackovergol.Data;
using stackovergol.Data.Entity;
using stackovergol.Data.Service;
using stackovergol.Infra.Security;
using stackovergol.Middlewares;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<MatchService>();
builder.Services.AddScoped<EventService>();

var connection = builder.Configuration.GetValue<string>("MySqlConnection:MySqlConnectionString");
builder.Services.AddDbContextPool<DataContext>(
    options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 21)))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
    
);

builder.Services.AddCors();
//Obtem dados do AppSettings
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

//Obtém a chave
var secret = builder.Configuration.GetValue<string>("AppSettings:Secret");
var key = Encoding.ASCII.GetBytes(secret);

//Configura a autenticação e o Bearer
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

/*
 *             app.UseDefaultFiles();
            //wwwroot css, JavaScrip, and images.
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Uploads")),
                RequestPath = new PathString("/Uploads")
            });
 */

app.UseStaticFiles();
app.MapControllers();

app.Run();
