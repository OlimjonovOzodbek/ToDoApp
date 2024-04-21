using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Abstractions;
using Todo.Application.UseCases.Commands;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.Handlers.CommandsHandler
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpadteCommentCommand, Comment>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateCommentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Comment> Handle(UpadteCommentCommand request, CancellationToken cancellationToken)
        {
            var res = await _appDbContext.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res is null)
                throw new Exception("User not found");

            res.IssueId = request.Id;
            res.SenderId = request.SenderId;
            res.Message = request.Message;

            _appDbContext.Comments.Update(res);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return res;
        }
    }
}
