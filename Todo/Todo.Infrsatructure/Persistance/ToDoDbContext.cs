using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Abstractions;
using Todo.Domain.Entities;
using Todo.Domain.Entities.Auth;

namespace Todo.Infrastructure.Persistence
{
    public class ToDoDbContext : IdentityDbContext<User, Role, Guid>, IAppDbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<ProgTask> Issues { get; set; }
        public DbSet<Comment> Comments { get; set; }

        async ValueTask<int> IAppDbContext.SaveChangesAsync(CancellationToken cancellationToken)
            => await base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            var role = new Role() { Id = Guid.NewGuid(), Name = "TeamLead", NormalizedName = "TEAMLEAD" };
            //Add role seed data

            builder.Entity<Role>().HasData(
                role,
                new Role() { Id = Guid.NewGuid(), Name = "Backend", NormalizedName = "BACKEND" },
                new Role() { Id = Guid.NewGuid(), Name = "Frontend", NormalizedName = "FRONTEND" },
                new Role() { Id = Guid.NewGuid(), Name = "FullStack", NormalizedName = "FULLSTACK" }
                );



            // Add user seed data
            User user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = "Admin",
                FullName = "AdminAdminovich",
                Description = "Adminni accounti",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            passwordHasher.HashPassword(user, "dotNET2020!");
            builder.Entity<User>().HasData(user);



            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = role.Id,
                UserId = user.Id
            });

        }
    }
}
