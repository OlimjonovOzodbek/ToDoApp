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
        public Guid IssueId {  get; set; }
        public string UserId { get; set; } 
        public virtual Issue Issue { get; set; }
        public virtual User User { get; set; }
    }
}
