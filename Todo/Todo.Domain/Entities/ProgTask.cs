using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Todo.Domain.Entities.Auth;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class ProgTask
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTimeOffset Deadline { get; set; }
        public Guid UserId { get; set; }

        public virtual List<Comment> Comments { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
