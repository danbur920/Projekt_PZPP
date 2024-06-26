
using RabbitMQService.Services;

namespace RabbitMQService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IRabbitMQService, Services.RabbitMQService>();
            builder.Services.AddControllers();
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
            app.UseRouting(); // This should come before app.UseEndpoints()
            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
