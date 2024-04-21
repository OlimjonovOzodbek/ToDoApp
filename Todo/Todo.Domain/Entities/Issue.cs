using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class Issue
    {
        public Guid id {  get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProgrammerId { get; set; }
        public IssueStatus Status {  get; set; } 
        public List<Comments> Comments {  get; set; }
        public DateTime CreatedDate {  get; set; } = DateTime.UtcNow;
        public DateTime Deadline { get; set;}
    }
}
