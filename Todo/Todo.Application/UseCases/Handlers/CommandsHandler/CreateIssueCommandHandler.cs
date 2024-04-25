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
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, ProgTask>
    {
        private readonly IAppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateIssueCommandHandler(IAppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ProgTask> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            string fileName = "";
            string filePath = "";
            if (request.Photo is not null)
            {
                var file = request.Photo;


                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProgTask", fileName);
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
            var task = new ProgTask()
            {
                FullName = request.FullName,
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                CreatedDate = request.CreatedDate,
                Deadline = request.Deadline,
                UserId = request.ProgrammerId,
                PhotoPath = "/ProgTask"+fileName
            };
            await _context.Issues.AddAsync(task);
            await _context.SaveChangesAsync(cancellationToken);
            return task;

        }
    }
}
