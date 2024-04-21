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
    public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, Issue>
    {
        private readonly IAppDbContext _context;
        public UpdateIssueCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Issue> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = await _context.Issues.FirstOrDefaultAsync(x => x.id == request.Id);

            if (issue is null)
                throw new Exception("Issue Not Found!");

            var entry = _context.Issues.Update(issue);

            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
