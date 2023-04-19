using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ZAD_REK.Models;
using ZAD_REK.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var conStrBuilder = new SqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("Default")
        );

conStrBuilder.Password = builder.Configuration["DBPassword"];

var connection = conStrBuilder.ConnectionString;

// Add services to the container.



builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IAccountService,AccountService>();

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(connection,
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        });


});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        //Dodatkowy margines czasu
        ClockSkew = TimeSpan.FromMinutes(2),
        //Kto jest poprawnym wydawc¹ tokena
        ValidIssuer = "https://localhost:7282",
        ValidAudience = "https://localhost:7282",
        // Jak jest podpisany
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["PassSecret"]))
    };
});

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
