using API_EF_Hash_Token.API.Infrastructure;
using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Services;
using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Interfaces;
using API_EF_Hash_Token.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

RSA rsa = RSA.Create(2048);
string key = Encoding.Default.GetString(API_EF_Hash_Token.API.Properties.Resources.key);
rsa.ImportRSAPrivateKey(API_EF_Hash_Token.API.Properties.Resources.key, out int bytesRead);
//rsa.ImportFromPem(key);

// DB
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(Encoding.Default.GetString(rsa.Decrypt(API_EF_Hash_Token.API.Properties.Resources.connectionString, RSAEncryptionPadding.OaepSHA512)))
    //opt.UseSqlServer(builder.Configuration.GetConnectionString("default"))
    );

// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Auth
builder.Services.AddScoped<IAuthRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Adress
builder.Services.AddScoped<IAdressRepository, AdressRepository>();
builder.Services.AddScoped<IAdressService, AdressService>();

// Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Category
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Sizes
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<ISizeService, SizeService>();

// Orders
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Token
builder.Services.AddSingleton<TokenManager>();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200", "https://localhost:7011", "http://localhost:8100")
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
    // Récupération de l'instance unique de TokenManager
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

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adminPolicy", policy => policy.RequireRole("Admin")); //Lire la valeur du claim Role dans le token
    options.AddPolicy("modoPolicy", policy => policy.RequireRole("Modo", "Admin")); // multiple role
    options.AddPolicy("connectedPolicy", policy => policy.RequireAuthenticatedUser()); //Vérifier que le token est bien valide
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
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();

app.Run();
