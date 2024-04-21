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

namespace Todo.Application.UseCases.Handlers.QueriesHandler
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<Comment>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllCommentsQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Comment>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            return _appDbContext.Comments.ToListAsync();
        }
    }
}
