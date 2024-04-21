using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Abstractions;
using Todo.Application.UseCases.Commands;

namespace Todo.Application.UseCases.Handlers.CommandsHandler
{
    public class DeleteCommendCommandHandler : IRequestHandler<CommentDeleteCommand, bool>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteCommendCommandHandler(IAppDbContext context)
        {
            _appDbContext = context;   
        }
        public async Task<bool> Handle(CommentDeleteCommand request, CancellationToken cancellationToken)
        {
            _appDbContext.Comments.Remove(_appDbContext.Comments.FirstOrDefault(x => x.Id == request.Id)!);
           await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
