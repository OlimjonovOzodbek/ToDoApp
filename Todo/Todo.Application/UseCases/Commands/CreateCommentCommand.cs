using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities.Auth;
using Todo.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Todo.Application.UseCases.Commands
{
    public class CreateCommentCommand : IRequest<Comment>
    {
        public string Message { get; set; }
        public Guid SenderId { get; set; }
        public Guid ProgTaskId { get; set; }
    }
}
