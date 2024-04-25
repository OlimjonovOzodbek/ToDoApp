using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Enums;

namespace Todo.Domain.DTOS
{
    public class ProgTaskDTO
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTimeOffset Deadline { get; set; }
        public IFormFile PhotoPath { get; set; }
        public Guid UserId { get; set; }
    }
}
