using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.Commands
{
    public class DeleteIssueCommand : IRequest<ProgTask>
    {
        public Guid Id { get; set; }
    }
}
