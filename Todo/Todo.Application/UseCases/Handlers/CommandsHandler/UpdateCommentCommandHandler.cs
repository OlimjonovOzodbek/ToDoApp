using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Abstractions;
using Todo.Application.UseCases.Commands;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.Handlers.CommandsHandler
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Comment>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateCommentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var res = await _appDbContext.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res is null)
                throw new Exception("User not found");

            res.IssueId = request.Id;
            res.Message = request.Message;

            _appDbContext.Comments.Update(res);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return res;
        }
    }
}
