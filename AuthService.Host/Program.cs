using AuthService.Domain;
using AuthService.Host.Routes;
using AuthService.Infrastructure.Contexts;
using AuthService.Infrastructure.Extensions;
using AuthService.Infrastructure.Managers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


// http://localhost:80

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("DefaultConnection")
    : Environment.GetEnvironmentVariable("CONNECTION_STRING");

var key = Encoding.ASCII.GetBytes("my_secret_key777");
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "AuthService",
        ValidAudience = "AuthClient",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});




const string specificorigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: specificorigins,
        policyBuilder =>
        {
            policyBuilder
                .WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddBusinessLogic(builder.Configuration, connectionString!);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
////TODO: 2 Вариант
//app.UseAuthentication();
app.UseAuthorization();
app.UseAuthentication();



app.AddUserRouter();



app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp");
    options.RoutePrefix = "";
});






app.UseHttpsRedirection();



app.Run();

public class AuthOptions
{
    public const string ISSUER = "AuthService";
    public const string AUDIENCE = "AuthClient";
    const string KEY = "samiy_nadezniy_key_v_mire!777";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}