using System;
using Todo.Domain.Entities.Auth;

namespace Todo.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public Guid UserId { get; set; } 
        public Guid IssueId { get; set; }
        public virtual User Sender { get; set; }
        public virtual Task Issue { get; set; }
    }
}
