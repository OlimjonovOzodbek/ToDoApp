using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateCommentCommandHandler(IAppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            string fileName = "";
            string filePath = "";
            if (request.Photo is not null)
            {
                var file = request.Photo;


                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Comment", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }
                catch (Exception ex)
                {
                    new Exception("Error while upload comment photo");
                }
            }

            Comment comment = new Comment()
            {
                Message = request.Message,
                UserId = request.SenderId,
                IssueId = request.IssueId,
                PhotoPath = "Comments/" + fileName
            };
            await _appDbContext.Comments.AddAsync(comment);
            await _appDbContext.SaveChangesAsync();
            return comment;
        }

    }
}
