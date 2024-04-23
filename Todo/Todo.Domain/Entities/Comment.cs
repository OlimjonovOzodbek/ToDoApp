using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Todo.Domain.Entities.Auth;

namespace Todo.Domain.Entities
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Message { get; set; }
        public Guid UserId { get; set; } 
        public Guid IssueId { get; set; }
        public Guid ProgTaskId {  get; set; }
        public string? PhotoPath { get; set; }

        [ForeignKey(nameof(ProgTaskId))]
        public virtual ProgTask ProgTask { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(IssueId))]
        public virtual Task Issue { get; set; }
    }
}
