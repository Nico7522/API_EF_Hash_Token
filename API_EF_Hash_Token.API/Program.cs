using API_EF_Hash_Token.API.Infrastructure;
using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Services;
using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Interfaces;
using API_EF_Hash_Token.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<TokenManager>();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
}));


builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    // R�cup�ration de l'instance unique de TokenManager
    var tokenManager = builder.Services.BuildServiceProvider().GetService<TokenManager>();

    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManager._secret)),
        ValidateIssuer = true,
        ValidIssuer = tokenManager._issuer, // Utilisation de l'Issuer du TokenManager
        ValidateAudience = true,
        ValidAudience = tokenManager._audience, // Utilisation de l'Audience du TokenManager
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    var db = app.Services.CreateScope().ServiceProvider.GetService<DataContext>();
    db?.Database.EnsureCreated();

}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();

app.Run();