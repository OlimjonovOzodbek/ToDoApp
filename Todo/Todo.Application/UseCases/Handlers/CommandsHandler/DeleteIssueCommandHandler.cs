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
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, Domain.Entities.ProgTask>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteIssueCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ProgTask> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = await _appDbContext.ProgTask.FirstOrDefaultAsync(x => x.id == request.Id);

            if (issue is null)
                throw new Exception("Issue not found");

            _appDbContext.ProgTask.Remove(issue);

            await _appDbContext.SaveChangesAsync();

            return issue;
        }
    }
}
