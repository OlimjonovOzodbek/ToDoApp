using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Abstractions;
using Todo.Application.UseCases.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Entities.Auth;

namespace Todo.Application.UseCases.Handlers.CommandsHandler
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Comment>
    {
        private readonly IAppDbContext _appDbContext;
        public CreateCommentCommandHandler(IAppDbContext context)
        {
            _appDbContext = context;
        }
        public async Task<Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment comment = new Comment()
            {
                Message = request.Message,
                SenderId = request.SenderId,
                IssueId = request.IssueId,
            };
            await _appDbContext.Comments.AddAsync(comment);
            await _appDbContext.SaveChangesAsync();
            return comment;
        }

    }
}
