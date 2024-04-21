using Todo.Domain.Entities.Auth;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class Issue
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTimeOffset Deadline { get; set; }
        public Guid ProgrammerId { get; set; }
        public virtual User Programmer { get; set; }
    }
}
