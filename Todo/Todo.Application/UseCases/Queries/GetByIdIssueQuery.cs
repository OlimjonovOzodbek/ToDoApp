using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.Queries
{
    public class GetByIdIssueQuery : IRequest<Issue>
    {
        public Guid Id {  get; set; }
    }
}
