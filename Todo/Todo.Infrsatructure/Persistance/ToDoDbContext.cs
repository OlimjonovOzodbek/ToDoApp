using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Abstractions;
using Todo.Domain.Entities;
using Todo.Domain.Entities.Auth;

namespace Todo.Infrastructure.Persistence
{
    public class ToDoDbContext : IdentityDbContext<User>, IAppDbContext
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

            // Add any custom entity configurations or relationships here if needed
        }
    }
}
