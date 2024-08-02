
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TabHubAPI.DataAccess;

namespace TabHubAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ThDbContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

            var app = builder.Build();

            /*
            using var scope = app.Services.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<ThDbContext>();
            dbContext.Database.EnsureCreated();
            */

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.MapControllers();

            app.Run();
        }
    }
}
