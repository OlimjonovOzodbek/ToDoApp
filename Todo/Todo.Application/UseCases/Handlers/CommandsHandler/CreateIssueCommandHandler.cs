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
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, ProgTask>
    {
        private readonly IAppDbContext _context;
        public CreateIssueCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ProgTask> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = new ProgTask()
            {
                FullName = request.FullName,
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                CreatedDate = request.CreatedDate,
                Deadline = request.Deadline,
                UserId = request.ProgrammerId,
            };
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync(cancellationToken);
            return issue;

        }
    }
}
