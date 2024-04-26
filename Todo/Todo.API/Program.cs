using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.Entities.Auth;
using Todo.Infrastructure.Persistence;

namespace Todo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                    builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ToDoDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ToDoDbContext>();


            // Configure endpoints
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("_myAllowSpecificOrigins");

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
