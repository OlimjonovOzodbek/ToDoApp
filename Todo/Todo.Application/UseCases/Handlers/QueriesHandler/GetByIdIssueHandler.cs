using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Abstractions;
using Todo.Application.UseCases.Queries;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.Handlers.QueriesHandler
{
    public class GetByIdIssueHandler :IRequestHandler<GetByIdIssueQuery, Issue>
    {
        private readonly IAppDbContext _context;

        public GetByIdIssueHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Issue> Handle(GetByIdIssueQuery request, CancellationToken cancellationToken)
        {
            return _context.Issues.FirstOrDefault(x => x.id == request.id)!;
        }
    }
}
