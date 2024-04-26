using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Todo.Domain.Entities.Auth;

namespace Todo.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string? Message { get; set; }
        public Guid ProgTaskId {  get; set; }
        public Guid UserId { get; set; } 
        public virtual ProgTask ProgTask { get; set; }
        public virtual User User { get; set; }
    }
}
