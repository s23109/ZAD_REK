using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ZAD_REK.Models;
using ZAD_REK.Services;

var builder = WebApplication.CreateBuilder(args);

var conStrBuilder = new SqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("Default"));

conStrBuilder.Password = builder.Configuration["DBPassword"];

var connection = conStrBuilder.ConnectionString;

// Add services to the container.

builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IAccountService,AccountService>();

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(connection);
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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
