using MediatR;
using Microsoft.AspNetCore.Hosting;
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
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, Issue>
    {
        private readonly IAppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateIssueCommandHandler(IAppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<Issue> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            string fileName = "";
            string filePath = "";
            if (request.File is not null)
            {
                var file = request.File;


                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Issues", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }
                catch
                {
                    new Exception("Error while upload comment photo");
                }
            }
            var task = new Issue()
            {
                Title = request.Title,
                Description = request.Description,
                CreatedDate = request.CreatedDate,
                Deadline = request.Deadline,
                FilePath = "/Issues"+fileName
            };
            await _context.Issues.AddAsync(task);
            await _context.SaveChangesAsync(cancellationToken);
            return task;

        }
    }
}
