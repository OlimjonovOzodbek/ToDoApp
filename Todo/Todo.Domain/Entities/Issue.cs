using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Todo.Domain.Entities.Auth;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class Issue
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTimeOffset Deadline { get; set; }
        public string FilePath { get; set; }
        public string TaskCreaterId { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual User TaskCreator { get; set; }
    }
}
