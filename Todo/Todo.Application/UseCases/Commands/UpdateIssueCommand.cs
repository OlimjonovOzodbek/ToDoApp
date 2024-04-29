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
    public class UpdateIssueCommand : IRequest<ProgTask>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public bool IsClosed { get; set; } = false;
        public FormFile FilePath { get; set; }
    }
}
