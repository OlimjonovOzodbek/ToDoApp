using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.UseCases.Commands;
using Todo.Application.UseCases.Handlers.CommandsHandler;
using Todo.Application.UseCases.Queries;
using Todo.Domain.Entities;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCommentCommand createCommand)
        {
            var createdComment = await _mediator.Send(createCommand);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdComment.Id }, createdComment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var comments = await _mediator.Send(new GetAllCommentsQuery());
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var comment = await _mediator.Send(new GetCommentByIdQuery { Id = id });
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateCommentCommand updateCommand)
        {
            if (id != updateCommand.Id)
            {
                return BadRequest("Resource ID mismatch");
            }

            var updatedComment = await _mediator.Send(updateCommand);
            return Ok(updatedComment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
