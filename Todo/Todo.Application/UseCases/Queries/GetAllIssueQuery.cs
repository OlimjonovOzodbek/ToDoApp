using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Entities.Auth;

namespace Todo.Application.UseCases.Queries
{
    public class GetAllIssueQuery : IRequest<IEnumerable<Domain.Entities.ProgTask>>
    {
    }
}
