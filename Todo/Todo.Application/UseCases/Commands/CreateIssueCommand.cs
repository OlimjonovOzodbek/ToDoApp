using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Enums;

namespace Todo.Application.UseCases.Commands
{
    public class CreateIssueCommand: IRequest<Issue>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTimeOffset Deadline { get; set; }
        public bool IsClosed { get; set; } = false;
        public IFormFile File { get; set; }
        public string TaskCreaterId { get; set; }
    }
}
