using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Application.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<Domain.Entities.ProgTask> ProgTask { get; set; }
        DbSet<Comment> Comments { get; set; }

        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
