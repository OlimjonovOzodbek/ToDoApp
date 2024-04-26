using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Todo.Domain.Entities.Auth;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class ProgTask
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTimeOffset Deadline { get; set; }
        public string PhotoPath { get; set; }
        public string UserId { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual User User { get; set; }
    }
}
