using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.UseCases.Commands
{
    public class CommentDeleteCommand:IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
