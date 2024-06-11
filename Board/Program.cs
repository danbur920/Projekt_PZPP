using Board.Repositories.Interfaces;
using Board.Repositories;
using Board.Services.Interfaces;
using Board.Services;
using Board.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Board.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7058")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Add DbContext with connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//public BoardController(IBoardService boardService, IHttpClientFactory httpClientFactory)

builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure the database exists and apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        var retryCount = 0;
        var maxRetryCount = 10;
        var delay = TimeSpan.FromSeconds(10);

        while (retryCount < maxRetryCount)
        {
            try
            {
                dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
                break;
            }
            catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 1801)
            {
                // Handle the exception if the database already exists
                Console.WriteLine("Database already exists.");
                break;
            }
            catch (Exception)
            {
                retryCount++;
                Console.WriteLine($"Waiting for SQL Server to start... Retry count: {retryCount}");
                Thread.Sleep(delay);
            }
        }

        if (retryCount == maxRetryCount)
        {
            Console.WriteLine("Failed to connect to SQL Server.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while ensuring the database exists and applying migrations: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
