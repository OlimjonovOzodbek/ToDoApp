using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.UseCases.Commands;
using Todo.Application.UseCases.Handlers.CommandsHandler;
using Todo.Application.UseCases.Queries;
using Todo.Domain.Entities;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IMediator _mediator;
        public Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Comment> Create(CreateCommentCommand create)
        {
            var result = await _mediator.Send(create);
            return result;
        }

        [HttpGet]
        public async Task<List<Comment>> GetAll()
        {
            var result = await _mediator.Send(new GetAllCommentsQuery());
            return result;
        }
        [HttpGet("Id")]
        public async Task<Comment> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCommentByIdQuery { Id = id });
            return result;
        }
        [HttpPatch]
        public async Task<Comment> Update(UpdateCommentCommand update) 
        {
            var result = await _mediator.Send(update);
            return result;
        }
        [HttpDelete]
        public async Task<bool> Delete(CommentDeleteCommand delete) 
        {
            var result = await _mediator.Send(delete);
            return result;
        }
        

    }
}
