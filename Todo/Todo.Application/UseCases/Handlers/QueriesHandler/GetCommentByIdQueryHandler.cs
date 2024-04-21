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
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
    {
        private readonly IAppDbContext _appDbContext;

        public GetCommentByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _appDbContext.Comments.FirstOrDefaultAsync(x=>x.Id == request.Id);

            if (res == null)
                throw new Exception("Not found Excepion");

            return res;
        }
    }
}
