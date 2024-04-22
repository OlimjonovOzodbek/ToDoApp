using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Abstractions;
using Todo.Application.UseCases.Queries;
using Todo.Domain.Entities;
using Todo.Domain.Entities.Auth;

namespace Todo.Application.UseCases.Handlers.QueriesHandler
{
    public class GetAllIssueQueryHandler: IRequestHandler<GetAllIssueQuery,IEnumerable<Domain.Entities.ProgTask>>
    {
        private readonly IAppDbContext _context;

        public GetAllIssueQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgTask>> Handle(GetAllIssueQuery request, CancellationToken cancellationToken)
        {
            return await _context.ProgTask.ToListAsync();
        }
    }
}
