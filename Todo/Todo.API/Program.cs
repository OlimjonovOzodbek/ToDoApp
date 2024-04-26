using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.Entities.Auth;
using Todo.Infrastructure.Persistence;

namespace Todo.API
{
    public class Program
    {
        public static async Task Main(string[] args)
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

            builder.Services.AddIdentity<User, IdentityRole>()
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

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "TeamLead", "Backend", "Frondend", "Fullstack" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string email = "admin@gmail.com";
                string password = "dotNET11!";

                if(await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new User()
                    {
                        FullName = email,
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true,
                        Description = password,
                    };

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "TeamLead");
                }
            }

            app.Run();
        }
    }
}
